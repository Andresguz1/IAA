using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBases : MonoBehaviour
{
    public float vidas = 300;
    public bool vb = true;
    public Image barraDeVida;

    void Start()
    {
    }


    void Update()
    {
        vidas = Mathf.Clamp(vidas, 0, 300);
        barraDeVida.fillAmount = vidas / 300;



        if (vidas == 0)
        {
            vb = false;
           // Destroy(gameObject);
           
        }





    }
}