using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscudoInst : MonoBehaviour
{
    public bool activo;
    public GameObject escudo;
    public Image powerShootEscudo;
    void Start()
    {
        
    }
    void Update()
    {
        escudo.transform.localPosition = Vector3.zero;
        if(Input.GetKey(KeyCode.Q) && activo==true)
        {
            escudo.SetActive(true);
            powerShootEscudo.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("escudo"))
        {
            activo = true;
            Destroy(other.gameObject);
        }

    }
}
