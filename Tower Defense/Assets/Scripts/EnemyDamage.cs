using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Tower tower;

    [SerializeField] int currentHealth = 15;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip destroySFX;
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
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, .3f) ;
        hitParticlesPrefab.Play();
        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        float particleDuration = deathVFX.main.duration;
        AudioSource.PlayClipAtPoint(destroySFX,Camera.main.transform.position);
        Debug.Break();
        Destroy(gameObject);
        Instantiate(deathVFX, transform.position, Quaternion.identity);
    }
}
