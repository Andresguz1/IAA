using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerUp : MonoBehaviour
{
    public float PowerUp;
    public GameObject prefabLuz;
    public GameObject prefabRafaga;
    public GameObject prefabPowerShoot;


    private void OnDestroy()
    {
        GeneraPowerUp(); 
    }

    void GeneraPowerUp()
    {
        if (PowerUp == 0 || PowerUp == 1)
        {
            Instantiate(prefabLuz, gameObject.transform.position, prefabLuz.transform.rotation);
            // Destroy(prefabLuz, 6f);


        }

        if (PowerUp == 2)
        {

            Instantiate(prefabRafaga, gameObject.transform.position, prefabRafaga.transform.rotation);
            //Destroy(prefabRafaga, 6f);

        }

        if (PowerUp == 3)
        {
            Instantiate(prefabPowerShoot, gameObject.transform.position, prefabPowerShoot.transform.rotation);
            // Destroy(prefabPowerShoot, 6f);

        }
    }
}
