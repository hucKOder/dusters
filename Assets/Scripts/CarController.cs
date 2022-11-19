using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 15;
    public float turnSpeed = 60;

    private float _horizontalInput;
    private float _verticalInput;

    private void FixedUpdate()
    {
        GetInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * _verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _horizontalInput);
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}
