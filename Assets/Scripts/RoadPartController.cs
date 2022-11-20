using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadPartController : MonoBehaviour
{
    //public Transform StartTransform;
    public Transform EndTransform;


    public GameObject[] Obstacles;

    private GameObject spawnedObstacle;

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
        if (EndTransform != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(EndTransform.position, new Vector3(1, 1, 1));
        }
    }

    public void AddRandomObstacle()
    {
        if (Obstacles?.Length > 0)
        {
            int obstacleIndex = Random.Range(0, Obstacles.Length - 1);
            spawnedObstacle = Instantiate(Obstacles[obstacleIndex], transform);
        }
    }

    public void CleanupObstacles()
    {
        if (spawnedObstacle != null)
            Destroy(spawnedObstacle);
    }
}
