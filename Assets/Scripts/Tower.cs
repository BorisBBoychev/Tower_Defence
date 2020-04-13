using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters for tower
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float targetDistance = 10f;
    [SerializeField] private ParticleSystem bullets;

    //State of tower
    Transform enemyToTarget;


    void Update()
    {
        SetTargetEnemy();
        if (enemyToTarget)
        {
            objectToMove.LookAt(enemyToTarget);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }

        enemyToTarget = closestEnemy;
    }

    private Transform GetClosest(Transform a, Transform b)
    {
        var distanceA = Vector3.Distance(transform.position, a.position);
        var distanceB = Vector3.Distance(transform.position, b.position);
        if (distanceA < distanceB)
        {
            return a;
        }
        return b;
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
}
