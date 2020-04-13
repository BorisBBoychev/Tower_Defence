using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [Range(0.1f , 120f)]
    [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private GameObject enemyToSpawn;

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
