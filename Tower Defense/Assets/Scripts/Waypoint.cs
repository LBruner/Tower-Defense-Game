using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredfrom;
    public bool isPlaceable = true;

    [SerializeField] Color exploredColor;
    [SerializeField] Tower tower;

    const int gridSize = 10;

    Vector2Int gridPos;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                SpawnTower();
            }
                
            else
                Debug.Log("Cant Place Block");
        }
    }

    private void SpawnTower()
    {
      var towerPlaced = Instantiate(tower, transform.position, Quaternion.identity);
        isPlaceable = false;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
