using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10;

    [Header("No tocar")]
    public float tiempo;

    void Start()
    {
        tiempo = 5; // es lo mismo que this.tiempo=5
        

        //Destroy(this, 2); // Destruir solo el componente
        Destroy(gameObject, 2); // Destruir todo el objeto  (luego de 2 segundos)
    }

    void Update()
    {
        tiempo = Time.deltaTime;
        transform.Translate(0,0,velocidad * Time.deltaTime);
    }
}
