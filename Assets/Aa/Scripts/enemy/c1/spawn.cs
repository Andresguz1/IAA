using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject enemigo;
    void Start()
    {
        InvokeRepeating("spawnear", 0.3f, 0.5f);
    }

    void Update()
    {
        
    }

    void spawnear()
    {
        int i = Random.Range(1,4);
        Instantiate(enemigo, spawnPoint[i].transform.position, transform.rotation);
    }
}
