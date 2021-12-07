using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{
    private gameOver GameOverbase;
    private YouWin Win;
    [SerializeField]
    public int escena;

    void Start()
    {
        GameOverbase = GameObject.Find("Jugador").GetComponent<gameOver>(); 
        Win = GameObject.Find("Jugador").GetComponent<YouWin>();
    }

  
    void Update()
    {
        //if(GameOverbase.ResetBase==true && Input.GetKey(KeyCode.F))
        //{
        //    SceneManager.LoadScene(escena);
        //}
        if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(escena);
        }
      
    }
}
