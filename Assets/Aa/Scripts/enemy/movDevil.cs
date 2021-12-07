using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDevil : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointsIndex;
    private float dista;
   
    public float vidionRadio;
    GameObject player; //para guardar jugador
    Vector3 initialposition;//posicion inicial
    public float PowerUp;
    //public GameObject prefabLuz;
    //public GameObject prefabRafaga;
    //public GameObject prefabPowerShoot;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    public bool gameActivo = true;
    private VidaPlayer vida;
    // private Vida3 vidaGordo;
    void Start()
    {
        waypointsIndex = 0;
        transform.LookAt(waypoints[waypointsIndex].position);
        //
        player = GameObject.FindGameObjectWithTag("Player");

        initialposition = transform.position;


        vida = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        if (vida.vida == 0)
        {
            gameActivo = false;
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
    void Update()
    {
        Vector3 target = initialposition;


        if (gameActivo == true)
        {



            float dist = Vector3.Distance(player.transform.position, transform.position);
            //if (dist < vidionRadio)
            //{
            //    vidionRadio = 30;
            //    target = player.transform.position;

            //    float fixedSpeed = speed * Time.deltaTime;
            //    transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            //    Debug.DrawLine(transform.position, target, Color.green);
            //}
            //else
            {
                dista = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);
                if (dista < 1f)
                {

                    increseIndex();
                }
                Patrol();
            }
            //  PowerUp = Random.Range(0, 3);

        }
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void increseIndex()
    {
        waypointsIndex++;
        if (waypointsIndex >= waypoints.Length)
        {
            waypointsIndex = 0;
        }
        transform.LookAt(waypoints[waypointsIndex].position);
    }
}
