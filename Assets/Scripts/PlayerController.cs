using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Adds a slider for adjusting Torque on susamongus
    [SerializeField] float torqueAmount = 1f;
    

    // Adds slider to adjust boosted ski speed
    [SerializeField] float boostSpeed =  60f;

    // Adds slider to adjust normal ski speed
    [SerializeField] float baseSpeed = 50f;

    // Creates a variable for calling susamongus physical body
    Rigidbody2D rb2d;
   
    // Creates Variable to call the Level Surface from the Inspector
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    // First Frame Start
    void Start()
    {
        //Calls susamongus physical body from the inspector
        rb2d = GetComponent<Rigidbody2D>();

        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // A list of all the methods being called to move and change the player
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
       canMove = false;
    }



     void RespondToBoost()
    {
       // if we push up, then speed up
    if (Input.GetKey(KeyCode.UpArrow))
    {
        surfaceEffector2D.speed = boostSpeed;
    }
      // otherwise stay at normal speed
    else
    {
        surfaceEffector2D.speed = baseSpeed;
    }
     
    }

    void RotatePlayer()
    {
        //Adds the keyboard controller for spinning susamongus using the left arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        //Adds the keyboard controller for spinning susamongus using the right arrow
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
