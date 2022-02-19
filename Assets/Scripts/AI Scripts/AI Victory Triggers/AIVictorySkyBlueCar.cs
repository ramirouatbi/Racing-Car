using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIVictorySkyBlueCar : MonoBehaviour
{
    public int currentLap;
    public int maxLap;

    void Start()
    {
        currentLap = maxLap;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AIfullskybluecar")
        {
            currentLap--;
            if (currentLap <= 0)
            {
                SceneManager.LoadScene("Player Victory Screen");
            }
        }

    }
}
