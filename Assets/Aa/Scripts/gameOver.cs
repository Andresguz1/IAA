using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    //private VidaBases bases;
    //private VidaBase2 base1;
    //private VidaBasePrincipal castillo;
    public GameObject textGameOver;
    public VidaPlayer vidaJ;
    public bool ResetBase=false;   
    void Start()
    {
      //  bases = GameObject.Find("Base").GetComponent<VidaBases>();
      //  base1 = GameObject.Find("Base2").GetComponent<VidaBase2>();
     //   castillo = GameObject.Find("BasePrincipal").GetComponent<VidaBasePrincipal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaJ.vida == 0)
        {
            SoundSystem.instance.PlayGameOver();
            textGameOver.SetActive(true);
            Destroy(gameObject);
            ResetBase = true;
        }

        //if(bases.vidas==0 && base1.vida==0 && castillo.vida == 0)
        // {
        //     SoundSystem.instance.PlayGameOver();
        //     textGameOver.SetActive(true);
        //     Destroy(gameObject);
        //     ResetBase = true;
        // }
    }
}
