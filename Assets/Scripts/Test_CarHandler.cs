using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
[RequireComponent(typeof(Rigidbody))]
public class Test_CarHandler : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSpeed = 2.0f;


    public float gravity = 20.0f;
    Rigidbody r;
    bool grounded = false;

    // Start is called before the first frame update 
    void Start()
    {
        r = GetComponent<Rigidbody>();
        //r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; 
        //r.freezeRotation = true;
        r.useGravity = false;
    }

    // Update is called once per frame 
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        gameObject.transform.RotateAroundLocal(
            Vector3.up,
            h * turnSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // We apply gravity manually for more tuning control 
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        if (r.velocity.magnitude < 10)
        {
            r.AddForce(transform.forward * speed * r.mass, ForceMode.Force);
        }

        grounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
}
