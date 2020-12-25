﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();      
    }

    


    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        LabelUpdate();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
    
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void LabelUpdate()
    {

        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        transform.name = labelText;
    }
}