using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 500;
    public int corazones;
    public Image barraDeVida;
    public Image corazon1;
    public Image corazon2;
    public Image corazon3;
    public GameObject textGameOver;
    public gameOver gameOverUno;
    public bool vivo=true;

    void Start()
    {
        corazones = 3;
        gameOverUno = GameObject.Find("Jugador").GetComponent<gameOver>();

    }
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 500);
        barraDeVida.fillAmount = vida / 500;
        if(vida==0)
        {
            DisminucionCorazones();
            
        }

     


        if (corazones == 0)
        {
            textGameOver.SetActive(true);
            corazon3.gameObject.SetActive(false);
            Destroy(gameObject);
            gameOverUno.ResetBase = true;
            gameObject.SetActive(false);
            SoundSystem.instance.PlayDeath();
            SoundSystem.instance.PlayGameOver();
        }
    }



    void DisminucionCorazones()
    {
        corazones -= 1;
        corazon1.gameObject.SetActive(false);
        vida = 500;

        if(corazones ==1)
        {
            corazon2.gameObject.SetActive(false);
        }
    }
}
