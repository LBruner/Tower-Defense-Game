using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    Tower tower;

    [SerializeField] int currentHealth = 15;
    [SerializeField] ParticleSystem deathVFX;
    private void Start()
    {
        
    }
    private void Update()
    {
        tower = FindObjectOfType<Tower>();
    }
    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(tower.damagePerShot);

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
    }
}
