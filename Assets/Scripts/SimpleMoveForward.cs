using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMoveForward : MonoBehaviour
{
    public float Speed = 0.2f;

    public Vector3 Direction = Vector3.forward;

    private Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
       // r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Direction * Speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //r.AddForce(Direction * Speed * r.mass / 10);
    }
}
