using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    int aux;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetRandomSpawner", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void GetRandomSpawner()
    {
        aux = Random.Range(0, spawners.Length);
        spawners[aux].SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        spawners[aux].SetActive(false);
    }

}
