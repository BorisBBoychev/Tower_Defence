using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    [SerializeField] private float secondsBetweenSpawns = 10f;
    [SerializeField] private EnemyMovement enemyToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        while (true)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
