using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform player;

    //Other Variables
    private VidaPlayer playerScript;
    public float damage;

    private void Awake()
    {
        playerScript = FindObjectOfType<VidaPlayer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerScript.vida = playerScript.vida - 20f;
            //Destroy(gameObject);
        }
        Debug.Log("col");
        Destroy(gameObject);
    }
}

