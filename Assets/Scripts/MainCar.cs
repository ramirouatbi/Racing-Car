﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCar : MonoBehaviour
{
    public static MainCar instance;
    public Rigidbody2D rb;
    public float turningForce = 0.4f;
    private float turningAmount, speed, direction;
    public float forward = 25f, reverse = 15f;

    //smoke trail
    public ParticleSystem[] tyreSmoke;
    public float maxSmoke = 25f;
    private float smokeRate;
    public float power;

    //Engine Sound
    public float maxSpeed;
    public AudioSource engine;


    //Tyre Skid Sound
    public AudioSource skidSound;
    public float skidFadeSpeed;

    //skid trail variables
    public GameObject leftTyre;
    public GameObject rightTyre;


    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(power) > .5f)
        {
            smokeRate = maxSmoke;
        }
        if (rb.velocity.magnitude <= .5f)
        {
            smokeRate = 0;
        }

        for(int i=0;i<tyreSmoke.Length;i++)
        {
            var emissionModule = tyreSmoke[i].emission;

            emissionModule.rateOverTime = smokeRate;
        }

        if(engine != null)
        {
            engine.pitch = 1f + ((rb.velocity.magnitude / maxSpeed) * 2f);
        }

        if(skidSound != null)
        {
            StartSkid();
            if(Mathf.Abs(turningAmount)>0.99f)
            {
                skidSound.volume = 1f;
            }
            else
            {
                skidSound.volume = Mathf.MoveTowards(skidSound.volume, 0f, skidFadeSpeed * Time.deltaTime);
                StopSkid();
            }
        }
    }

    void FixedUpdate()
    {
        turningAmount = -Input.GetAxis("Horizontal");
        speed = 0f;
        if (Input.GetAxis("Accelerator") > 0)
        {
            speed = Input.GetAxis("Accelerator") * forward;
        }
        else if (Input.GetAxis("Reverse") < 0)
        {
            speed = Input.GetAxis("Reverse") * reverse;
        }

        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += turningAmount * turningForce * rb.velocity.magnitude * direction;
        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * turningAmount / 2);
    }

    private void StartSkid()
    {
        leftTyre.GetComponent<TrailRenderer>().emitting = true;
        rightTyre.GetComponent<TrailRenderer>().emitting = true;
    }

    private void StopSkid()
    {
        leftTyre.GetComponent<TrailRenderer>().emitting = false;
        rightTyre.GetComponent<TrailRenderer>().emitting = false;
    }
}
