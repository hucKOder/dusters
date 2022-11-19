<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        gameObject.transform.RotateAroundLocal(
            Vector3.up,
            h * speed * Time.deltaTime);


        gameObject.transform.position += transform.forward * Time.deltaTime * speed;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarHandler : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 2.0f;


    public float gravity = 20.0f;
    Rigidbody r;
    bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        //r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        gameObject.transform.RotateAroundLocal(
            Vector3.up,
            h * turnSpeed * Time.deltaTime);


        gameObject.transform.position += transform.forward * Time.deltaTime * speed;
    }

    void FixedUpdate()
    {
        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        grounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
}
>>>>>>> 89117c5 (Endless Road Generation)
