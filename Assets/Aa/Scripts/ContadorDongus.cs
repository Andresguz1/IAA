using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorDongus : MonoBehaviour
{
    
    public Text dongEliminados;
    private PlayerShoot flechaAtaque;
    
    void Start()
    {

        flechaAtaque = GameObject.Find("Jugador").GetComponent<PlayerShoot>();
        
    }

    // Update is called once per frame
    void Update()
    {
       ContadorEnemigosDongus();
    }

    void ContadorEnemigosDongus()
    {
       
        dongEliminados.text = "" + flechaAtaque.contadorDonEliminados;
    }
}
