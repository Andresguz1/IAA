using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class e7 : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    //public Transform p;
    Vector3 initialposition;//posicion inicial

    public float PowerUp;
    public GameObject enemy;
   

    public Text almas;
    public int contAlmas;



    public float damageTime;
    float currentDamageTime;



    public bool gameActivo = true;

    private VidaPlayer vida;
    public NavMeshAgent agente;

    private VidaPlayer jugador;
    [SerializeField]
    public int cantidad = 20;


    void Start()
    {
        // variacionAtaque = Random.Range(0, 2);

        NavMeshAgent agente = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;

        agente.destination = player.transform.position;
        vida = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        if (vida.vida == 0)
        {
            gameActivo = false;
        }
    }


    void FixedUpdate()
    {

        agente.destination = player.transform.position;

        //if (gameActivo == true)
        //{
        //    Vector3 target = initialposition;



        //        float dist = Vector3.Distance(player.transform.position, transform.position);
        //        if (dist < vidionRadio) target = player.transform.position;

        //        float fixedSpeed = speed * Time.deltaTime;
        //        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        //        Debug.DrawLine(transform.position, target, Color.green);

        //}
    }
    private void Update()
    {
        PowerUp = Random.Range(0, 3);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PLayer")
        {
            jugador.vida -= cantidad;
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                currentDamageTime = 0.0f;

            }
        }

        if (other.gameObject.CompareTag("flecha") || other.gameObject.CompareTag("SuperFlecha"))
        {
            // almas.text = contAlmas + 1.ToString();
            Destroy(gameObject);
            Debug.Log("f");
            generaPowerUp();
            generaPowerUp();

        }
        if (other.gameObject.CompareTag("Espada"))
        {
            Debug.Log("fw");
            Destroy(gameObject);
            generaPowerUp();
            generaPowerUp();

        }
    }

    
    void generaPowerUp()
    {     
            Instantiate(enemy, gameObject.transform.position, enemy.transform.rotation);
    }
}
