using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EspadaIns : MonoBehaviour
{
    
    public Transform posicion;
    public GameObject espada;
  //  public EspadaRotacion esp;
    
    public float tiempoRot;
    public float velociadRotacion;
    void Start()
    {
        
    }
    void Update()
    {
        tiempoRot += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && tiempoRot>velociadRotacion)
        {          
            SoundSystem.instance.PlayBara();
            espada.gameObject.SetActive(true);      
            tiempoRot = 0;
        }
    }
}


