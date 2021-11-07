using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ola1 : MonoBehaviour
{
    private float rangoGeneracion = 20f;
    private float rangoGeneracionZ = -12f;
    public GameObject prefabEnemigo;
 
   
   
    

    public float intervaloGeneracion = 6f;
    public int numEnemigos;
    private float cont;

    
    public Text pts;
    void Start()
    {
       

        SoundSystem.instance.PlayOla();
        GeneradorEnemigos(10); 
    }


    void Update()
    {
        numEnemigos = FindObjectsOfType<Enemigo_Dongnus>().Length;
       
    }
    void GeneradorEnemigos(int numEnemigosAGenerar)
    {
        for (int i = 0; i < numEnemigosAGenerar; i++)
        {
           
            Instantiate(prefabEnemigo, DamePosicionGeneracion(), prefabEnemigo.transform.rotation);
       
            cont++;
            pts.text = cont.ToString();
        }
    }
 

    Vector3 DamePosicionGeneracion()
    {
        float posXGeneracion = Random.Range(-20f, rangoGeneracion);
        Vector3 posAleatoria = new Vector3(posXGeneracion, 0, rangoGeneracionZ);
        return posAleatoria;
    }
}
