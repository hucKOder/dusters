using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPartController : MonoBehaviour
{
    //public Transform StartTransform;
    public Transform EndTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        //if (StartTransform != null)
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireCube(StartTransform.position, new Vector3(1, 1, 1));
        //}

        if (EndTransform != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(EndTransform.position, new Vector3(1, 1, 1));
        }
    }
}
