using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthManager.instance.DamagePlayer();

        }

    }
}
