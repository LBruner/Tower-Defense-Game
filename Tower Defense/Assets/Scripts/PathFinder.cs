using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]bool isRunning = true;

    Waypoint searchCenter;

    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,       
        Vector2Int.right
        };

    [SerializeField] Waypoint startPos, endPos;


    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endPos);
 
        Waypoint previous = endPos.exploredfrom;
        while(previous != startPos)
        {
            previous = previous.exploredfrom;
            SetAsPath(previous);
        }

        SetAsPath(startPos);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPos);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            StopIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;               
        }
    }

    private void StopIfEndFound()
    {
        if(searchCenter == endPos){
            isRunning = false;
        }
    }

    private  void ExploreNeighbors()
    {
        if (!isRunning)
            return;
       foreach(Vector2Int direction in directions)
        {
            Vector2Int NeighborCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(NeighborCoordinates))
                EnqueuNewNeighbors(NeighborCoordinates);
                    
        }
    }

    private void EnqueuNewNeighbors(Vector2Int NeighborCoordinates)
    {

        Waypoint neighbor = grid[NeighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor))
            return;
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredfrom = searchCenter;
        }
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                //Debug.Log("Overlaping" + waypoint);
            }

            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
