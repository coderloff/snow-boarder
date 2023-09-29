using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1;
    [SerializeField] float boostSpeed = 30;
    [SerializeField] float baseSpeed = 20;

    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespontToBoost();
        }
    }

    private void RespontToBoost()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetAxisRaw("Vertical") == 1)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        rb.AddTorque(-Input.GetAxisRaw("Horizontal") * torqueAmount);
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
