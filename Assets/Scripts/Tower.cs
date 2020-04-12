using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;
    [SerializeField] private Transform enemyToTarget;

    private void LookAtEnemy()
    {
        objectToMove.LookAt(enemyToTarget);
    }
    void Update()
    {
        LookAtEnemy();
    }
}
