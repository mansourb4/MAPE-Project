using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb2D => GetComponent<Rigidbody2D>();

    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 groundCheckDimensions;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private float movementSpeed;

    private bool isGrounded;
    private float horizontalInput;

    private void OnJump()
    {
        if (isGrounded)
        {
            rb2D.velocity += Vector2.up * jumpForce;
        }
    }

    private void OnHorizontalMovement(InputValue axis)
    {
        horizontalInput = axis.Get<float>();
    }
    
    private void Update()
    {
        CheckForGround();
    }
    
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontalInput * movementSpeed, rb2D.velocity.y);
    }

    private void CheckForGround()
    {
        isGrounded = Physics2D.BoxCast(transform.position, groundCheckDimensions, 0f,
            -transform.up, 0.1f, platformLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, (Vector3)groundCheckDimensions);
    }
}