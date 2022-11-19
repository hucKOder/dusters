using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration = 8f;
    public float turnStrength = 180;
    public float gravity = 10f;
    public float dragOnGround = 3f;
    public Rigidbody rb;
    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;
    public Transform leftWheel;
    public Transform rightWheel;
    public float maxWheelTurn = 25;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _grounded;

    private void Start()
    {
        rb.transform.parent = null;
    }

    private void FixedUpdate()
    {
        CheckGround();

        if (_grounded)
        {
            Move();
        } else
        {
            Fall();
        }
    }

    private void CheckGround()
    {
        _grounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            _grounded = true;
            // Copy terrain rotation
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }

    private void Move()
    {
        rb.drag = dragOnGround;
        rb.AddForce(transform.forward * acceleration);
    }

    private void Fall()
    {
        rb.drag = 0.1f;
        rb.AddForce(Vector3.up * -gravity * 100f);
    }

    private void Turn()
    {
        if (_grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, _horizontalInput * turnStrength * Time.deltaTime, 0f));
        }
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void TurnWheels()
    {
        leftWheel.localRotation = Quaternion.Euler(leftWheel.localRotation.eulerAngles.x,
            (_horizontalInput * maxWheelTurn) - 180, leftWheel.localRotation.eulerAngles.z);
        rightWheel.localRotation = Quaternion.Euler(rightWheel.localRotation.eulerAngles.x,
            (_horizontalInput * maxWheelTurn), rightWheel.localRotation.eulerAngles.z);
    }

    private void Update()
    {
        GetInput();
        Turn();
        TurnWheels();
        transform.position = new Vector3(rb.position.x, transform.position.y, rb.position.z);

        
    }
}
