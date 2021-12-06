using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    GoldLife gold;

    float currentTime = 0f;
    public float StartingTime = 120f;
    public Text timeText;
    public GameObject spawner;
    public GameObject nextLevelDoor;

    private void Start()
    {
        gold = FindObjectOfType<GoldLife>();
        currentTime = StartingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = currentTime.ToString("0");

        if (currentTime <= 0 && gold.gold > 0)
        {
            currentTime = 0;
            spawner.SetActive(false);
            nextLevelDoor.SetActive(true);
        }

    }
}
