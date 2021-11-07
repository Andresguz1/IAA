using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1 : MonoBehaviour
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

    public int variacionAtaque;
    public int torresAleatoria;
    public int asignacionEnemigo;
    public int base2rando;
    public int castilloRandom;
    public int cantidad;
    public int DosBases;

    public float damageTime;
    float currentDamageTime;

    private VidaBases bases;
    private VidaBase2 base1;
    private VidaBasePrincipal castillo;

    public bool gameActivo = true;

    private VidaPlayer vida;

    void Start()
    {
       // variacionAtaque = Random.Range(0, 2);
        torresAleatoria = Random.Range(0, 3);
        asignacionEnemigo = Random.Range(0, 3);
        base2rando = Random.Range(0, 3);
        castilloRandom = Random.Range(0, 3);
        DosBases = Random.Range(0, 2);

        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;

        bases = GameObject.Find("Base").GetComponent<VidaBases>();
        base1 = GameObject.Find("Base2").GetComponent<VidaBase2>();
        castillo = GameObject.Find("BasePrincipal").GetComponent<VidaBasePrincipal>();
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
            generaPowerUp();

        }
    }

    void TorreDestruida()
    {
        Vector3 target = initialposition;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < vidionRadio) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.green);
    }
    void generaPowerUp()
    {

        if (PowerUp == 0 || PowerUp == 1)
        {
            Instantiate(prefabLuz, gameObject.transform.position, prefabLuz.transform.rotation);
            Destroy(prefabLuz, 6f);


        }

        if (PowerUp == 2)
        {

            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
            Destroy(prefabRafaga, 6f);

        }

        if (PowerUp == 3)
        {
            Instantiate(prefabPowerShoot, gameObject.transform.position, prefabPowerShoot.transform.rotation);
            Destroy(prefabPowerShoot, 6f);

        }

    }
}
