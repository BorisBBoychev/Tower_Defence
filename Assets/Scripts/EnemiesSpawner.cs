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
    [SerializeField] public Text enemyCountText;
    public int enemyCounter;

    // Start is called before the first frame update
    void Start()
    {
        enemyCountText.text = "Enemies:" + enemyCounter.ToString();
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            enemyCounter++;
            enemyCountText.text = "Enemies:" + enemyCounter.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
