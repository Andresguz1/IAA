using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextleve : MonoBehaviour
{
    [SerializeField]
    public int escena;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            SceneManager.LoadScene(escena);
        }
    }
}
