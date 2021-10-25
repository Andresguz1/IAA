using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void OnTriggerEnter(Collider otro) {
        Debug.Log("trigger enter: " + otro.name);
    }

    void OnTriggerExit(Collider otro) {
        Debug.Log("saliendo: " + otro.name);
    }
}
