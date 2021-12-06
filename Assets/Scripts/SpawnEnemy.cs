using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyLvl4;
    private void OnEnable()
    {
        Instantiate(enemyLvl4, transform.position, transform.rotation);
    }
}
