using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage1 : MonoBehaviour
{
    
    private VidaPlayer jugador;
    [SerializeField]
    public int cantidad =10;


    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            jugador.vida -= cantidad;
            Debug.Log(jugador.vida);

        }
    }

   

    
}
