using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float spawnDelay = .5f;
    [SerializeField] Transform enemyparentGameobject;



    IEnumerator EnemySpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        var enemySpawned = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        enemySpawned.transform.parent = enemyparentGameobject;
        StartCoroutine(EnemySpawnDelay());

    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(EnemySpawnDelay());
    }
}
