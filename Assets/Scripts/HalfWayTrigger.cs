using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfWayTrigger : MonoBehaviour
{

    public GameObject halfWayTrig;
    public GameObject lapCompleteTrig;

    void OnTriggerEnter2D(Collider2D other)


    {
        if (other.tag == "Player")

        {
            lapCompleteTrig.SetActive(true);
            halfWayTrig.SetActive(false);
        }


    }

}