using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    public Transform seguidor;

    public void Seguir() {
        if(seguidor != null) {
            seguidor.position = transform.position;
        }
    }
}
