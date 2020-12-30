using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    
    [SerializeField] ParticleSystem enableTowerShooting;

    [SerializeField] float attackRange = 5f;

    public int damagePerShot = 5;

    public Waypoint basewaypoint;

    //STATE
    Transform enemyTarget;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (enemyTarget)
        {
            objectToPan.LookAt(enemyTarget);
            ShootCloseEnemies();
        }
        else
        {
            Shoot(false);
        }      
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
            return;

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy.transform, testEnemy.transform);
        }

        enemyTarget = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
    {
        float distanceToClosestEnemy = Vector3.Distance(closestEnemy.position, transform.position);
        float distanceToTestEnemy = Vector3.Distance(testEnemy.position, transform.position);

        if (distanceToTestEnemy < distanceToClosestEnemy)
        {
            return testEnemy;
        }

         return closestEnemy;
    }

    private void ShootCloseEnemies()
    {
        float distanceToEnemy = Vector3.Distance(enemyTarget.transform.position, transform.position);

        if (enemyTarget != null && distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
            Shoot(false);

    }

    private void Shoot(bool closeEnought)
    {
        var emissionModule = enableTowerShooting.emission;
        emissionModule.enabled = closeEnought;
    }
}
