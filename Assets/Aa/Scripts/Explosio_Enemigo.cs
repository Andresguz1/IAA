using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosio_Enemigo : MonoBehaviour
{
    public ParticleSystem explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundSystem.instance.PlayExplosion();
            explosion.Play();
            Destroy(gameObject);
          
        }
    }
}
