using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyLVL8 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Image hpBar;

    //Patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Atacando
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //Estados
    public float sightRange, attackRange;
    public bool playerInSightRange, playerinAttackRange;

    //Other Variables
    private VidaPlayer playerScript;
    public float health = 100;
    private float healthAux;
    public float damage;
    int ran;
    bool chasing = false;

    private void Awake()
    {
        playerScript = FindObjectOfType<VidaPlayer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        healthAux = health;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        hpBar.fillAmount = health / healthAux;


        if (!playerInSightRange && !playerinAttackRange)
        {
            Patroling();
            chasing = false;
        } 
        if (playerInSightRange && !playerinAttackRange) Chasing();
        if (playerinAttackRange && playerInSightRange) Attacking();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    int GetRandomNumber()
    {
        ran = Random.Range(0, 10);
        return ran;
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Objetivo Alcanzado
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    void Chasing()
    {
        if (chasing == false)
        {
            GetRandomNumber();
            chasing = true;
        }
        

        if (ran > 5)
        {
            agent.SetDestination(player.position);
        }
    }
    void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here

            playerScript.vida = playerScript.vida - damage;

            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flecha") || other.gameObject.CompareTag("SuperFlecha"))
        {
            //  almas.text = contAlmas + 1.ToString();
            health = health - 20;
            Destroy(other.gameObject);
            Debug.Log("f");
            //generaPowerUp();

        }

        if (other.gameObject.CompareTag("Espada"))
        {
            Debug.Log("fw");
            Destroy(gameObject);
            //generaPowerUp();

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
