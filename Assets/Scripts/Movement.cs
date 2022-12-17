using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float maxHorizontalTimer = 0.2f;

    private float horizontalInput;
    private float verticalInput;
    private float horizontalTimer;

    void Update()
    {
        UpdatePersonalComputer();
        UpdateMobile();
    }

    private void UpdateMobile()
    {
    }

    private void UpdatePersonalComputer()
    {
        horizontalInput = (Input.GetKeyDown("d") ? 1 : 0) + (Input.GetKeyDown("a") ? -1 : 0);
        verticalInput = (Input.GetKeyDown("w") ? 1 : 0) + (Input.GetKeyDown("s") ? -1 : 0);

        HorizontalMovement();
        VerticalMovement();
    }

    void HorizontalMovement()
    {
        if (horizontalTimer >= 0)
            horizontalTimer -= Time.deltaTime;
        else
        {
            rb.velocity = new Vector3(horizontalInput * 24, rb.velocity.y, rb.velocity.z);

            if (Math.Abs(horizontalInput) > float.Epsilon)
                horizontalTimer = maxHorizontalTimer;
        }
    }

    void VerticalMovement()
    {
        if (Math.Abs(verticalInput) < float.Epsilon) return;

        rb.velocity = new Vector3(rb.velocity.x, verticalInput * 10, rb.velocity.z);
    }
}