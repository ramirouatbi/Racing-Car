using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLives = 3;
    public float respawnTime = 2f;
    public GameObject pauseScreen;
    public string levelLoad;
    public bool isPaused;

    public AudioSource engine;
    public AudioSource monsterTruck;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUnpause();
        }
    }

    public void pauseUnpause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            engine.Stop();
            monsterTruck.Stop();
        }
        else
        {
            Time.timeScale = 1f;
            engine.Play();
            monsterTruck.Play();
        }
    }

    public void ExitRace()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelLoad);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

    public void KillPlayer()
    {
        currentLives--;
        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
        }
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnTime);
        HealthManager.instance.Respawn();

    }
}
