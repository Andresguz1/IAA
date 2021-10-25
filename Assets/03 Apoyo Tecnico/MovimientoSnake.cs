using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSnake : MonoBehaviour
{
    public int dirX;
    public int dirY;

    public Transform seguidor;


    IEnumerator Start()
    {
        dirX = 1;
        dirY = 0;

        while(true){
            yield return new WaitForSeconds(1f);
            if(seguidor != null){
                seguidor.GetComponent<Seguidor>().Seguir();
                seguidor.position = transform.position;
            }

            transform.Translate(dirX,dirY,0);
        }
    }


    void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            dirX = 0;
            dirY = 1;
        }
    }
}
