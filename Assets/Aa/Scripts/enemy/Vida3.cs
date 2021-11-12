using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida3 : MonoBehaviour
{
    public DamagePlayer dano;
    [SerializeField]
   public int vida = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida==0)
        {
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flecha")
        {
            vida -= dano.damage;
            
        }
    }

}
