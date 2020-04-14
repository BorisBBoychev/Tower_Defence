using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] private int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;
    void Start()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject , destroyDelay);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
