using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDongus : MonoBehaviour
{
    private VidaPlayer jugador;
    private VidaBases bases;
    private VidaBase2 base1;
    private VidaBasePrincipal castillo;
    public int cantidad;
    public float tiempoDeDaño;
    public float velocidadDaño;
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
        bases = GameObject.Find("Base").GetComponent<VidaBases>();
        base1 = GameObject.Find("Base2").GetComponent<VidaBase2>();
        castillo = GameObject.Find("BasePrincipal").GetComponent<VidaBasePrincipal>();
    }

   
    void Update()
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            tiempoDeDaño += Time.deltaTime;
            if(tiempoDeDaño >velocidadDaño)
            {
                jugador.vida -= cantidad;
                tiempoDeDaño = 0;
            }

         
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.vida -= cantidad;
        }
        


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Towers")
        {
            tiempoDeDaño += Time.deltaTime;
            if (tiempoDeDaño > velocidadDaño)
            {
                bases.vidas -= cantidad;
                tiempoDeDaño = 0;
            }
           
        }

        if (other.tag == "Towers1")
        {
            tiempoDeDaño += Time.deltaTime;
            if (tiempoDeDaño > velocidadDaño)
            {
                base1.vida -= cantidad;
                tiempoDeDaño = 0;
            }
          
        }

        if (other.tag == "Castle")
        {
            tiempoDeDaño += Time.deltaTime;
            if (tiempoDeDaño > velocidadDaño)
            {
                castillo.vida -= cantidad;
                tiempoDeDaño = 0;
            }
            
        }


    }

 

}
