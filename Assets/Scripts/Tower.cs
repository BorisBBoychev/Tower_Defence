using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;
    [SerializeField] private Transform enemyToTarget;
    [SerializeField] private float targetDistance = 10f;
    [SerializeField] private ParticleSystem bullets;

    private void LookAtEnemy()
    {
        objectToMove.LookAt(enemyToTarget);
    }

    void FireAtEnemy()
    {
        float distance = Vector3.Distance(enemyToTarget.transform.position, gameObject.transform.position);
        if (distance <= targetDistance)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }

    }

    void Shoot(bool isShooting)
    {
        var emision = bullets.emission;
        emision.enabled = isShooting;
    }

    void Update()
    {
        if (enemyToTarget)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
        
    }
}
