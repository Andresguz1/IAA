using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pu : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    Vector3 initialposition;//posicion inicial
    public float PowerUp;
    public GameObject prefabLuz;
    public GameObject prefabRafaga;
    public GameObject prefabPowerShoot;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    public bool gameActivo = true;
    private VidaPlayer vida;

    void Start()
    {
       

        player = GameObject.FindGameObjectWithTag("Player");
       
        initialposition = transform.position;

        
        vida = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        if (vida.vida == 0)
        {
            gameActivo = false;
        }
    }


    void FixedUpdate()
    {

        if (gameActivo == true)
        {

            Vector3 target = initialposition;

            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < vidionRadio) target = player.transform.position;

            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            Debug.DrawLine(transform.position, target, Color.green);

            PowerUp = Random.Range(0, 3);
        }
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
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                currentDamageTime = 0.0f;
            }
        }

        if (other.gameObject.CompareTag("flecha") || other.gameObject.CompareTag("SuperFlecha"))
        {
            generaPowerUp();

        }
        if (other.gameObject.CompareTag("Espada"))
        {
            Debug.Log("fff");
            generaPowerUp();

        }
    }

   
    void generaPowerUp()
    {

        if (PowerUp == 0 || PowerUp == 1)
        {
          
            Instantiate(prefabLuz, gameObject.transform.position, prefabLuz.transform.rotation);
           // Destroy(prefabLuz, 6f);


        }

        if (PowerUp == 2)
        {

            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
           // Destroy(prefabRafaga, 6f);

        }

        if (PowerUp == 3)
        {
            Instantiate(prefabPowerShoot, gameObject.transform.position, prefabPowerShoot.transform.rotation);
            //(prefabPowerShoot, 6f);

        }

    }
}