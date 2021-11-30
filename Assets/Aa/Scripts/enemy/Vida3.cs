using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida3 : MonoBehaviour
{
    public float PowerUp;
    public GameObject prefabLuz;
    public GameObject prefabRafaga;
    public GameObject prefabPowerShoot;
    public DamagePlayer dano;
    [SerializeField]
   public int vida = 50;
    void Start()
    {
        PowerUp = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (vida==0)
        {
            Destroy(gameObject);
            generaPowerUp();
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flecha")
        {
            vida -= dano.damage;
           
        }
    }
    void generaPowerUp()
    {
        if (PowerUp == 0 || PowerUp == 1)
        {
          
            Instantiate(prefabLuz, gameObject.transform.position, prefabLuz.transform.rotation);
            // Destroy(prefabLuz, 6f);
        }

        if (PowerUp == 2)
        {
            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
            // Destroy(prefabRafaga, 6f);
        }

        if (PowerUp == 3)
        {
            Instantiate(prefabPowerShoot, gameObject.transform.position, prefabPowerShoot.transform.rotation);
            //(prefabPowerShoot, 6f);
        }
    }

}
