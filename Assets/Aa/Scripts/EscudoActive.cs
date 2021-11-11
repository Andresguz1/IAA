using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscudoActive : MonoBehaviour
{
    public float cooldownEscudo;
    public Image powerShootEscudo;
    void Start()
    {
        
    }
     void OnEnable()
    {
        cooldownEscudo = 0;
    }

    void Update()
    {
        cooldownEscudo += Time.deltaTime;

    if(cooldownEscudo>3)
        {
            gameObject.SetActive(false);
            powerShootEscudo.gameObject.SetActive(false);
        }
    }
}
