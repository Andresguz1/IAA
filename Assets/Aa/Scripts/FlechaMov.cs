using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlechaMov : MonoBehaviour
{

    public float velFlecha;
   
    public PlayerShoot contadorEnemigos;
    public YouWin winer;
    

    void Start()
    {
        contadorEnemigos = GameObject.Find("Jugador").GetComponent<PlayerShoot>();
    }


    void Update()
    {
       

        transform.Translate(Vector3.up* velFlecha * Time.deltaTime);
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            

            Destroy(other.gameObject);
            Destroy(this.gameObject);
          
            contadorEnemigos.contadorDonEliminados += 1;
           
        }

        if (other.tag == "enemigoCeletris")
        {


            Destroy(other.gameObject);
            Destroy(this.gameObject);
       
            contadorEnemigos.contadorCeletrisEliminados += 1;

        }

        if (other.tag=="Towers" || other.tag =="Towers1" || other.tag =="Castle" || other.tag =="limite")
        {
            Destroy(this.gameObject);
        }
    }


   
}
