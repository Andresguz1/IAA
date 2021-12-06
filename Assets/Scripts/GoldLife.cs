using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldLife : MonoBehaviour
{
    public float gold;
    public Image goldAmount;
    public GameObject gameOverScreen;
    private float aux;

    private void Start()
    {
        aux = gold;
    }

    private void Update()
    {
        goldAmount.fillAmount = gold / aux;

        if (gold <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
