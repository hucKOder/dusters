using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

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

    public int tilesWithNoObstaclesTmp;

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
            AddSlopeVariation(spawnedRoad);
            spawnPosition = spawnedRoad.EndTransform.position;
            spawnOrientation = spawnedRoad.EndTransform.rotation;
            spawnedRoad.transform.SetParent(transform);
            SpawnedRoadPrefabs.Add(spawnedRoad);
            ActiveRoadPrefabsById[part] = spawnedRoad;

            // no obstacls first x tiles
            //if (tilesWithNoObstaclesTmp > 0)
            //{
            //    spawnedTile.DeactivateAllObstacles();
            //    tilesWithNoObstaclesTmp--;
            //}
            //else
            //{
            //    spawnedTile.ActivateRandomObstacle();
            //}

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
            SpawnedRoadPrefabs.RemoveAt(0);
            tileTmp.transform.position = SpawnedRoadPrefabs[^1].EndTransform.position;
            tileTmp.transform.rotation = SpawnedRoadPrefabs[^1].EndTransform.rotation;

            AddSlopeVariation(tileTmp);
            //tileTmp.ActivateRandomObstacle();
            SpawnedRoadPrefabs.Add(tileTmp);
        }
    }

    private void AddSlopeVariation(RoadPartController roadPart)
    {
        var slopeDir = 1;

        if (roadPart.transform.rotation.x > MaxSlope)
            slopeDir = -1;

        if (roadPart.transform.rotation.x < -MaxSlope)
            slopeDir = 1;

        var slopeChange = slopeDir * Random.Range(0, MaxSlopeChange);

        roadPart.transform.Rotate(Vector3.right, slopeChange);
    }

    //private void OnDrawGizmos()
    //{
    //    if (CarObject != null)
    //    {
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawWireSphere(CarObject.transform.position, GenerationDistance);
    //    }
    //}


}
