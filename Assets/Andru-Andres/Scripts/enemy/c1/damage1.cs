using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage1 : MonoBehaviour
{
    
    private VidaPlayer jugador;
    [SerializeField]
    public int cantidad =20;


    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
   
    }


    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.vida -= cantidad;
            Debug.Log("vida");
            Debug.Log(jugador.vida);
        }
    }

   

    
}
