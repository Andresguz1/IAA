using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movDevil : MonoBehaviour
{
   
    GameObject player; //para guardar jugador
    public bool gameActivo = true;

    //More Variables
    public float health;
    public Transform bulletSpawnPos;
    public GameObject bullet;
    public GameObject shooters;
    public float timeBetweenAttacks;
    Vector3 playerPos;
    bool alreadyAttacked;
    public bool playerInSightRange, playerinAttackRange;
    public float sightRange, attackRange;
    public LayerMask whatIsGround, whatIsPlayer;
    private VidaPlayer vidaScript;

    public Transform[] waypoints;
    public Transform[] lvl2BulletSpawnPos;
    public Transform[] enemySpawnPos;

    //Para UI
    public Image bar;
    float aux;
    public GameObject winBar;

    int currentWaypoint = 0;
    public float speed;
    float waypointRadius = 1;

    void Start()
    {
        aux = health;
        bar.color = new Color32(255, 0, 91, 255);
        player = GameObject.FindGameObjectWithTag("Player");
        vidaScript = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        if (vidaScript.vida <= 0)
        {
            gameActivo = false;
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        bar.fillAmount = health / aux;


        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPos);

        if (health >= 300 && health <= 500)
        {
            if (playerinAttackRange && playerInSightRange) Attacking();
        }

        if (health >= 100 && health <= 300)
        {
            if (playerinAttackRange && playerInSightRange) Attacking2();
            bar.color = new Color32(135, 0, 255, 255);
        }

        if (health >= 0 && health <= 100)
        {
            if (playerinAttackRange && playerInSightRange) Attacking3();
            bar.color = new Color32(255, 0, 0, 255);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            winBar.SetActive(true);
        }

        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }

    void Attacking()
    {
        transform.LookAt(player.transform.position);

        if (!alreadyAttacked)
        {
            //Attack code here

            Shoot();

            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    void Attacking2()
    {
        transform.LookAt(player.transform.position);
        if (!alreadyAttacked)
        {
            //Attack code here
            for (int i = 0; i < lvl2BulletSpawnPos.Length; i++)
            {
                Instantiate(bullet, lvl2BulletSpawnPos[i].position, lvl2BulletSpawnPos[i].rotation); ;
            }
            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void Attacking3()
    {
        transform.LookAt(player.transform.position);
        if (!alreadyAttacked)
        {
            //Attack code here
            for (int i = 0; i < enemySpawnPos.Length; i++)
            {
                Instantiate(shooters, enemySpawnPos[i].position, enemySpawnPos[i].rotation); ;
            }
            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 15);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation); ;
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "flecha")
        {
            health = health - 20;
            Destroy(other.gameObject);
        }
    }

}
