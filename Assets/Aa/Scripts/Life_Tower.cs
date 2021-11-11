using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Tower : MonoBehaviour
{
    public float vida = 150;
    public float vidmax = 150;
    public Image barraDeVida;
    void Start()
    {
        
    }

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, vidmax);
        barraDeVida.fillAmount = vida / vidmax;
        if (vida == 0)
        {
            Destroy(gameObject);
        }
    }
}
