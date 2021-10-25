using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo_Dongnus : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    GameObject tower;
    GameObject tower1;
    GameObject tower2;
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
        variacionAtaque = Random.Range(0, 2);
        torresAleatoria = Random.Range(0, 3);
        asignacionEnemigo = Random.Range(0, 3);
        base2rando = Random.Range(0 , 3);
        castilloRandom = Random.Range(0, 3);
        DosBases = Random.Range(0, 2);

        player = GameObject.FindGameObjectWithTag("Player");
        tower = GameObject.FindGameObjectWithTag("Towers");
        tower1 = GameObject.FindGameObjectWithTag("Towers1");
        tower2 = GameObject.FindGameObjectWithTag("Castle");
        initialposition = transform.position;

        bases = GameObject.Find("Base").GetComponent<VidaBases>();
        base1 = GameObject.Find("Base2").GetComponent<VidaBase2>();
        castillo = GameObject.Find("BasePrincipal").GetComponent<VidaBasePrincipal>();
        vida = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        if(vida.vida==0)
        {
            gameActivo = false;
        }
    }


    void FixedUpdate()
    {

        if (gameActivo == true)
        {
            Vector3 target = initialposition;


            if (variacionAtaque == 0)
            {
                float dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist < vidionRadio) target = player.transform.position;

                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                Debug.DrawLine(transform.position, target, Color.green);


            }


            if (variacionAtaque == 1)
            {

                if (torresAleatoria == 0 && bases.vb == true)
                {
                    //Vector3 target = initialposition;

                    float dist = Vector3.Distance(tower.transform.position, transform.position);
                    if (dist < vidionRadio) target = tower.transform.position;

                    float fixedSpeed = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                    Debug.DrawLine(transform.position, target, Color.green);
                }
                else if (bases.vb == false)
                {
                    float dist = Vector3.Distance(tower2.transform.position, transform.position);
                    if (dist < vidionRadio)
                    {

                        target = tower2.transform.position;

                        if (asignacionEnemigo == 0 && base1.vb2 == true)
                        {
                            torresAleatoria = 1;
                        }
                        if (asignacionEnemigo == 1 && castillo.vbCatle == true)
                        {
                            torresAleatoria = 2;
                        }
                        if (asignacionEnemigo == 2)
                        {

                            if (DosBases == 0)
                            {
                                variacionAtaque = 0;
                            }
                            if (DosBases == 1)
                            {
                                torresAleatoria = 2;
                            }
                        }
                    }

                }


                if (torresAleatoria == 1 && base1.vb2 == true)
                {
                    float dist = Vector3.Distance(tower1.transform.position, transform.position);
                    if (dist < vidionRadio) target = tower1.transform.position;

                    float fixedSpeed = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                    Debug.DrawLine(transform.position, target, Color.green);
                }

                else if (base1.vb2 == false)
                {
                    float dist = Vector3.Distance(tower2.transform.position, transform.position);
                    if (dist < vidionRadio)
                    {
                        target = tower2.transform.position;


                        if (base2rando == 1 && castillo.vbCatle == true)
                        {
                            torresAleatoria = 2;
                        }
                        else if (DosBases == 0)
                        {
                            variacionAtaque = 0;
                            if (DosBases == 1)
                                torresAleatoria = 0;
                        }

                        if (base2rando == 0 && bases.vb == true)
                        {
                            torresAleatoria = 0;
                        }
                        else if (DosBases == 0)
                        {
                            variacionAtaque = 0;
                            if (DosBases == 1)
                            {
                                torresAleatoria = 2;
                            }
                        }

                        if (base2rando == 2)
                        {

                            variacionAtaque = 0;

                        }
                    }

                }


                if (torresAleatoria == 2 && castillo.vbCatle == true)
                {
                    float dist = Vector3.Distance(tower2.transform.position, transform.position);
                    if (dist < vidionRadio) target = tower2.transform.position;
                    float fixedSpeed = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                    Debug.DrawLine(transform.position, target, Color.green);
                }
                else if (castillo.vbCatle == false)
                {
                    float dist = Vector3.Distance(player.transform.position, transform.position);
                    if (dist < vidionRadio)
                    {
                        target = player.transform.position;

                        if (castilloRandom == 0 && bases.vb == true)
                        {
                            torresAleatoria = 0;
                        }
                        else
                        {
                            variacionAtaque = 0;
                        }
                        if (castilloRandom == 1 && base1.vb2 == true)
                        {
                            torresAleatoria = 1;
                        }
                        else
                        {
                            variacionAtaque = 0;
                        }
                        if (castilloRandom == 2)
                        {

                            if (DosBases == 0)
                            {
                                variacionAtaque = 0;
                            }
                            if (DosBases == 1)
                            {
                                torresAleatoria = 1;
                            }
                        }
                    }

                }
            }
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

        if (other.gameObject.CompareTag("flecha")  || other.gameObject.CompareTag("SuperFlecha"))
        {
            generaPowerUp();

        }
        if (other.gameObject.CompareTag("Espada"))
        {
            generaPowerUp();

        }
    }

    void TorreDestruida()
    { Vector3 target = initialposition;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < vidionRadio) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.green);
    }
    void generaPowerUp()
    {
       
        if (PowerUp == 0 || PowerUp ==1)
        {
            Instantiate(prefabLuz, gameObject.transform.position, prefabLuz.transform.rotation);
            Destroy(prefabLuz, 6f);


        }

        if (PowerUp ==2)
        {

            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
            Destroy(prefabRafaga, 6f);

        }

        if (PowerUp == 3 ) 
        {
            Instantiate(prefabPowerShoot, gameObject.transform.position, prefabPowerShoot.transform.rotation);
            Destroy(prefabPowerShoot, 6f);

        }

    }
}