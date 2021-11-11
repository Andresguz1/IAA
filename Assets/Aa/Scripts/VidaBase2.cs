using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBase2 : MonoBehaviour
{
    public float vida = 300;
    public bool vb2 = true;
    public Image barraDeVida;
 
    void Start()
    {
      
    }

    void Update()
    {

        vida = Mathf.Clamp(vida, 0, 300);
        barraDeVida.fillAmount = vida / 300;


        if (vida == 0)
        {
            vb2 = false;    
          //  Destroy(gameObject);

        }

    }
}
