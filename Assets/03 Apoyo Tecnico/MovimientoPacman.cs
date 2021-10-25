using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPacman : MonoBehaviour
{
    float acumulador;

    void Start()
    {
        acumulador = 0;
    }

    void Update()
    {
        acumulador = acumulador + Time.deltaTime;
        if(acumulador >= 0.5f){
            acumulador = 0f;
            transform.Translate(0,0,1);
        }


        if(Input.GetKeyDown(KeyCode.RightArrow))
            transform.rotation = Quaternion.Euler(0,90,0);

        if(Input.GetKeyDown(KeyCode.UpArrow))
            transform.rotation = Quaternion.Euler(0,0,0);

        if(Input.GetKeyDown(KeyCode.DownArrow))
            transform.rotation = Quaternion.Euler(0,180,0);

        if(Input.GetKeyDown(KeyCode.LeftArrow))
            transform.rotation = Quaternion.Euler(0,-90,0);
            
    }
}
