using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaBasePrincipal : MonoBehaviour
{
    public float vida = 350;
    public bool vbCatle = true;
    public Image barraDeVida;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 350);
        barraDeVida.fillAmount = vida / 350;


        if (vida == 0)
        {
            vbCatle = false;
            //Destroy(gameObject);
        
        }

    }
}