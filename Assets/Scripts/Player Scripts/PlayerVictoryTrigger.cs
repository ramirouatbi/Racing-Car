using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVictoryTrigger : MonoBehaviour
{
    public int currentLap;
    public int maxLap;

    void Start()
    {
        currentLap = maxLap;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            currentLap--;
            if (currentLap <= 0)
            {
                SceneManager.LoadScene("Player Victory Screen");
            }
        }

    }



}