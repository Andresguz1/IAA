using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLVL4 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    AudioSource audioSource;

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
    private GoldLife goldScript;
    private VidaPlayer playerScript;
    public float damage;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        goldScript = FindObjectOfType<GoldLife>();
        playerScript = FindObjectOfType<VidaPlayer>();
        player = GameObject.FindGameObjectWithTag("Gold").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerinAttackRange) Patroling();
        if (playerInSightRange && !playerinAttackRange) Chasing();
        if (playerinAttackRange && playerInSightRange) Attacking();
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
        agent.SetDestination(player.position);
        sightRange = 65f;
    }
    void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            goldScript.gold = goldScript.gold - damage;
            audioSource.Play();

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
            Destroy(gameObject);
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
