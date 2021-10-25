using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador : MonoBehaviour
{
    public GameObject prototipo;

    public float periodo = 5;

    [Header("no tocar")]
    public float acumulador;

    void Start()
    {
        acumulador = 0;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            acumulador = acumulador + Time.deltaTime;
            if(acumulador >= periodo){
                acumulador = 0;

                Instantiate(prototipo, transform.position, transform.rotation);
            }
        }
    }
}
