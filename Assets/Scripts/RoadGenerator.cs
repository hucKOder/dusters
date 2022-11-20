using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [Range(3, 20)]
    public int GenerateParts = 3;

    public RoadPartController[] RoadPrefabs;

    public GameObject CarObject;

    public Camera MainCamera;

    [Range(0.0f, 10.0f)]
    public float MaxSlopeChange;

    [Range(0.0f, 45.0f)]
    public float MaxSlope;

    [Range(-200, 0)]
    public float PartsDissapearAtZFromCamera = -20;

    private List<RoadPartController> SpawnedRoadPrefabs = new();

    private Dictionary<int, RoadPartController> ActiveRoadPrefabsById = new();

    public int TilesWithoutObstacles = 5;

    [HideInInspector]
    public bool GameRunning;

    // Start is called before the first frame update
    void Start()
    {
        if (RoadPrefabs.Length == 0)
            throw new System.Exception("No road prefabs assigned in generator");

        if (RoadPrefabs.Any(x => x == null))
            throw new System.Exception("one or more road prefabs is null");

        if (MainCamera == null)
            throw new System.Exception("camera  is null");

        if (CarObject == null)
            throw new System.Exception("car object  is null");


        var part = 0;
        var spawnPosition = Vector3.zero;
        Quaternion spawnOrientation = Quaternion.identity;

        for (int i = 0; i <= GenerateParts; i++)
        {
            var spawnedRoad = Instantiate(RoadPrefabs[part], spawnPosition, spawnOrientation) as RoadPartController;
            spawnPosition = spawnedRoad.EndTransform.position;
            spawnOrientation = spawnedRoad.EndTransform.rotation;
            spawnedRoad.transform.SetParent(transform);
            SpawnedRoadPrefabs.Add(spawnedRoad);
            ActiveRoadPrefabsById[part] = spawnedRoad;


            if (TilesWithoutObstacles > 0)
            {
                TilesWithoutObstacles--;
            }
            else
            {
                spawnedRoad.AddRandomObstacle();
            }

            // change tile, make sure to not generate outside of list index
            part++;
            part %= RoadPrefabs.Length;
        }
        //int initialGenerate = g

        GameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameRunning)
            return;

        if (MainCamera.WorldToViewportPoint(SpawnedRoadPrefabs[0].EndTransform.position).z < PartsDissapearAtZFromCamera)
        {
            //Move the tile to the front if it's behind the Camera
            var tileTmp = SpawnedRoadPrefabs[0];
            tileTmp.CleanupObstacles();
            SpawnedRoadPrefabs.RemoveAt(0);
            tileTmp.transform.position = SpawnedRoadPrefabs[^1].EndTransform.position;
            tileTmp.transform.rotation = SpawnedRoadPrefabs[^1].EndTransform.rotation;
            tileTmp.AddRandomObstacle();

            //tileTmp.ActivateRandomObstacle();
            SpawnedRoadPrefabs.Add(tileTmp);
        }
    }

    
}
