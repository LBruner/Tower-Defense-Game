using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parentPos;

    Tower newTower;

    Queue<Tower> towers = new Queue<Tower>();
    // Start is called before the first frame update
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerLimit > towers.Count)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }         
            
    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = parentPos;
        baseWaypoint.isPlaceable = false;

        newTower.basewaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();       
        towers.Enqueue(oldTower);     
        
        oldTower.basewaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.basewaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;    
    }
}
