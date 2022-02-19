using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour
{
    public GameObject start;
    public AudioSource go;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartUp");
    }

    IEnumerator StartUp()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        go.Play();
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        start.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
