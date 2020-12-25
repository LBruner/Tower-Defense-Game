using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    [SerializeField] float delayTime = 1f;
    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            Debug.Log("Starting Patrol" + "Visiting block: " + waypoint.transform.position);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(delayTime);
        }
        Debug.Log("Ending Patrol");
    }
    void Update()
    {
    }
}
