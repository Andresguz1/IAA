using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorCeletris : MonoBehaviour
{
    public Text contadorCelet;
    public Text celetrisEliminados;
    private PlayerShoot flechaAtaque;
    void Start()
    {
        flechaAtaque = GameObject.Find("Jugador").GetComponent<PlayerShoot>();
    }

    
    void Update()
    {
        ContadorEnemigosCeletrisIgnis();
    }

    void ContadorEnemigosCeletrisIgnis()
    {
        contadorCelet.text = "" + flechaAtaque.contadorC;
       celetrisEliminados.text = "" + flechaAtaque.contadorCeletrisEliminados;
    }
}
