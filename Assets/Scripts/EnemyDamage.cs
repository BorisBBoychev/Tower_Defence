using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Collider collisionMesh;
    [SerializeField] private int hitPoints = 10;

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
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints -= 1;
    }
}
