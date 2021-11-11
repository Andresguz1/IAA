using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo_Explosivo : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador

    Vector3 initialposition;//posicion inicial
    public float ataque = 30;
    public float PowerUp;
    public GameObject prefabLuz;
    public GameObject prefabEscudo;
    public GameObject prefabRafaga;
 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;

    }

    void Update()
    {
        PowerUp = Random.Range(0, 3);

        Vector3 target = initialposition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < vidionRadio) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flecha") || other.gameObject.CompareTag("Espada") || other.gameObject.CompareTag("SuperFlecha"))
        {
            generaPowerUp();

        }
    }
    void generaPowerUp()
    {
       
        if (PowerUp == 0 || PowerUp ==1)
        {
            Instantiate(prefabLuz,gameObject.transform.position, prefabLuz.transform.rotation);
            Destroy(prefabLuz, 6f);
        }

        if (PowerUp == 2)
        {
            Instantiate(prefabEscudo, gameObject.transform.position, prefabEscudo.transform.rotation);
            Destroy(prefabEscudo, 6f);

        }

        if (PowerUp == 3)
        {
            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
            Destroy(prefabRafaga, 6f);

        }

    }
}
