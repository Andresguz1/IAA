using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MENU : MonoBehaviour
{
   public void escenaJuego()
    {
        SceneManager.LoadScene("Aa");
    }

    public void salir()
    {
        Application.Quit();
    }
}
