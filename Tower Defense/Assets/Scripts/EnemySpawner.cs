using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float spawnDelay = .5f;
    [SerializeField] Transform enemyparentGameobject;
    [SerializeField] Text scoreTtx;
    [SerializeField] AudioClip enemySpawnedSFX;
    PlayerHealth playerhealt;
    int enemyCount;
    



    IEnumerator EnemySpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        AudioSource.PlayClipAtPoint(enemySpawnedSFX,Camera.main.transform.position);
        var enemySpawned = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);    
        enemySpawned.transform.parent = enemyparentGameobject;

        enemyCount++;
        playerhealt.UpdateUI(enemyCount, scoreTtx);


        StartCoroutine(EnemySpawnDelay());

    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(EnemySpawnDelay());
        playerhealt = FindObjectOfType<PlayerHealth>();
    }
}
