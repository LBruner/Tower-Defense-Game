using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float moveDelay = 1f;
    [SerializeField] ParticleSystem autoDestructVFX;
    [SerializeField] float damageToPlayer = 5f;
    [SerializeField] AudioClip autoDestructSFX;
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(moveDelay);
        }
        Debug.Log("FINISHED");
        Autodestruct();


    }
    public void Autodestruct()
    {
        AudioSource.PlayClipAtPoint(autoDestructSFX, Camera.main.transform.position);
        Debug.Break();
        float particleDuration = autoDestructVFX.main.duration;
        Destroy(gameObject);
        Instantiate(autoDestructVFX, new Vector3(transform.position.x, 5.26f, transform.position.z), Quaternion.identity);

        PlayerHealth playerhealth;
        playerhealth = FindObjectOfType<PlayerHealth>();
        playerhealth.PlayerDamage(damageToPlayer);
    }
}
