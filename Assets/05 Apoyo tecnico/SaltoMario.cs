using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoMario : MonoBehaviour
{
    public AnimationCurve curve;

    void Start()
    {
        float x = curve.Evaluate(0.5f);
    }

    float tiempo;
    bool salto;
    float altura;

    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        tiempo = Mathf.Clamp01(tiempo);

        if(salto) {
            altura = curve.Evaluate(tiempo);

            //transform.position = pivote + new Vector3(0,altura,0);
        }
        
    }
}
