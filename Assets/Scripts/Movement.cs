using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float maxHorizontalTimer = 0.2f;

    private float horizontalInput;
    private float verticalInput;
    private float horizontalTimer;

    // Mobile Variables
    private Vector2 startPosition;
    private Vector2 deltaSwipe;

    void Update()
    {
        UpdatePersonalComputer();
        //UpdateMobile();
    }

    private void UpdateMobile()
    {
        horizontalInput = verticalInput = 0;

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startPosition = touch.position;
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                startPosition = deltaSwipe = Vector2.zero;
            else if (touch.phase == TouchPhase.Moved)
            {
                deltaSwipe = Vector2.zero;
                if (startPosition != Vector2.zero)
                    deltaSwipe = touch.position - startPosition;

                if (deltaSwipe.sqrMagnitude > 5000) // >70^2 units
                {
                    float x = deltaSwipe.x;
                    float y = deltaSwipe.y;

                    if (MathF.Abs(x) >= MathF.Abs(y))
                    {
                        if (x > 0) horizontalInput = 1;
                        else horizontalInput = -1;
                    }
                    else
                    {
                        if (y > 0) verticalInput = 1;
                        else verticalInput = -1;
                    }
                    startPosition = deltaSwipe = Vector2.zero;
                }
            }
        }

        HorizontalMovement();
        VerticalMovement();
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