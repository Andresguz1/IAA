using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    private PlayerShoot flechaAtaque;
    public bool ResetBase = false;
    public GameObject youWins;
    void Start()
    {
        flechaAtaque = GameObject.Find("Jugador").GetComponent<PlayerShoot>();
    }

   
    void Update()
    {
        //if(flechaAtaque.contadorCeletrisEliminados>25&& flechaAtaque.contadorDonEliminados >110 )
        //{
        //    youWins.gameObject.SetActive(false);
        //    ResetBase = true;
        //}
    }
}
