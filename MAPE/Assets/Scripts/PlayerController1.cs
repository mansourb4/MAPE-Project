using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    private CustomInput _input = null;
    private Vector2 _moveVector = Vector2.zero;

    private void Awake()
    {
        _input = new CustomInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Movement.performed += OnMovementPerformed;
        _input.Player.Movement.performed += OnMovementCancelled;

    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Movement.performed -= OnMovementPerformed;
        _input.Player.Movement.performed -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        Debug.Log(_moveVector);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector2>();
    }
    
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        _moveVector = Vector2.zero;
    }
}
