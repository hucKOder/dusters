using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleWalkController : MonoBehaviour
{
    public Transform[] Points;

    public bool Cycle = false;

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 20;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    private Vector3 currentDirection = Vector3.zero;

    private bool isAlive = true;

    private Queue<Transform> positionQueue = new();

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var pos in Points)
            positionQueue.Enqueue(pos);

        if (positionQueue.Count > 0)
        {
            var start = positionQueue.Peek();
            gameObject.transform.position = start.position;
            gameObject.transform.rotation = start.rotation;
            currentDirection = gameObject.transform.forward;
        }
        m_animator.SetBool("Grounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (positionQueue.Count == 0)
        {
            m_animator.SetBool("Grounded", true);
            m_animator.SetFloat("MoveSpeed", 0);
            return;
        }

        var target = positionQueue.Peek();

        if (Vector3.Distance(gameObject.transform.position, target.transform.position) > 0.2)
        {
            var desiredDir = (target.transform.position - gameObject.transform.position);
            desiredDir.Normalize();

            currentDirection = Vector3.Lerp(transform.forward, desiredDir, m_turnSpeed);
            var newPos = transform.position + currentDirection * m_moveSpeed * Time.deltaTime;

            transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
            transform.rotation = Quaternion.LookRotation(currentDirection);

            m_animator.SetFloat("MoveSpeed", m_moveSpeed);
        }
        else
        {
            var next = positionQueue.Dequeue();

            if (Cycle)
            {
                positionQueue.Enqueue(next);
            }
        }
    }
}
