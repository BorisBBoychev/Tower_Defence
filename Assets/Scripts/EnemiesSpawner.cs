using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class EnemiesSpawner : MonoBehaviour
{
    [Range(0.1f , 120f)]
    [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
