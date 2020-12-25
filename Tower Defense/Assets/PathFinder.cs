using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startPos, endPos;
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
                Debug.Log("Overlaping" + waypoint);
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }                
        }
    }

    private void ColorStartAndEnd()
    {
        startPos.SetTopColor(Color.green);
        endPos.SetTopColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
