using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muro : MonoBehaviour
{
    public int vidaMuro = 50;
    public DamagePlayer dano;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaMuro == 0)
        {
            Destroy(gameObject);
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flecha")
        {
            vidaMuro -= dano.damage;

        }
    }
}
