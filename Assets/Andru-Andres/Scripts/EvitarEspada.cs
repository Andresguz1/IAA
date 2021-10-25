using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarEspada : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "espada")
        {
            Debug.Log("lo se");
        }
    }
}
