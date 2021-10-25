using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoCeletrisIgnis : MonoBehaviour
{
    private VidaPlayer jugador;
    private VidaBases bases;
    private VidaBase2 base1;
    private VidaBasePrincipal castillo;
    public int cantidad;
    
  
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
      
           
          jugador.vida -= cantidad;
           



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Towers")
        {
           
                bases.vidas -= cantidad;
                
            
        }

        if (other.tag == "Towers1")
        {
           
                base1.vida -= cantidad;
               
       

        }

        if (other.tag == "Castle")
        {
           
                castillo.vida -= cantidad;
                
           

        }


    }
}
