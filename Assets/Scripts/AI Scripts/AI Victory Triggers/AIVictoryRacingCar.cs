using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIVictoryRacingCar : MonoBehaviour
{
    public int currentLap;
    public int maxLap;

    void Start()
    {
        currentLap = maxLap;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AIfullracingcar")
        {
            currentLap--;
            if (currentLap <= 0)
            {
                SceneManager.LoadScene("AIVictoryScreen");
            }
        }

    }
}
