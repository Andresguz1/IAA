using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArrow : MonoBehaviour
{
    public float velFlecha;
    public float contadorEnemigos;
    public PlayerShoot contadorDongus;

    void Start()
    {
        contadorDongus = GameObject.Find("Jugador").GetComponent<PlayerShoot>();

    }
    void Update()
    {

        transform.Translate(Vector3.up * velFlecha * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemigo")
        {

            Destroy(other.gameObject);
            contadorDongus.contadorD -= 1;
            contadorDongus.contadorDonEliminados += 1;
        }
        if (other.tag == "enemigoCeletris")
        {


            Destroy(other.gameObject);
            Destroy(this.gameObject);
            contadorDongus.contadorC -= 1;
            contadorDongus.contadorCeletrisEliminados += 1;

        }

        if (other.tag == "limite")
        {
            Destroy(this.gameObject);
        }
    }
}
