using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float velocidadMov=5;
    public float velocidadCorrer;
    public bool correr;
    public float velocidadNormal;
    public Light antorcha;
   
    

    void Start()
    {
        

    }
    void Update()
    {

        antorcha.spotAngle -= 0.005f;


        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Correr();
           
            
        }
        else
        {

            Caminar();
        }
      
       
        if (Input.GetKey(KeyCode.W))//Movimiento arriba
        {
            transform.Translate(Vector3.forward * velocidadMov * Time.deltaTime,Space.World);
        }

        if (Input.GetKey(KeyCode.S))//Movimiento Abajo
        {
            transform.Translate(Vector3.back * velocidadMov * Time.deltaTime,Space.World);
        }

        if (Input.GetKey(KeyCode.D))//Movimiento Derecha
        {
            transform.Translate(Vector3.right * velocidadMov * Time.deltaTime,Space.World);
        }

        if (Input.GetKey(KeyCode.A))//Movimiento Izquierda
        {
            transform.Translate(Vector3.left * velocidadMov * Time.deltaTime,Space.World);
        }

    }
     void Correr()
    {
        correr = true;
        velocidadMov = velocidadCorrer;
        antorcha.spotAngle -= 0.08f;
    }
    void Caminar()
    {
        correr = false;
        velocidadMov = velocidadNormal;
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Luz"))
        {
            antorcha.spotAngle += 7;
            Destroy(other.gameObject);
        }
    }
}
