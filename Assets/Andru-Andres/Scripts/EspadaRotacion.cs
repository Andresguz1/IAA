using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaRotacion : MonoBehaviour
{
    public float velRot;
    public float coolDown;
    public float tiempoIns;
    public bool desactivado;
    public PlayerShoot contadorEnemigos;
    void Start()
    {
        contadorEnemigos = GameObject.Find("Jugador").GetComponent<PlayerShoot>();

        desactivado = true;
    }

    void OnEnable()
    {
         coolDown = 0;
    }
    void Update()
    {
       
        transform.Rotate(Vector3.forward * velRot);
        coolDown += Time.deltaTime;
        if (coolDown > 0.7)
        {
           
           gameObject.SetActive(false);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            Destroy(other.gameObject);
            contadorEnemigos.contadorD -= 1;
            contadorEnemigos.contadorDonEliminados += 1;
        }
        if (other.tag == "enemigoCeletris")
        {
            Destroy(other.gameObject);
            contadorEnemigos.contadorC -= 1;
            contadorEnemigos.contadorCeletrisEliminados += 1;
        }


       
    }
}
