using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledEnemies : MonoBehaviour
{
    public EnemyDamage enemyDamagScript;
    [SerializeField] private Text enemyUI;
    private int killCounter;
    void Start()
    {
        enemyUI.text = "x " + killCounter.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (enemyDamagScript.SendKillMessage())
        {
            killCounter++;
        }
        enemyUI.text = "x " + killCounter.ToString();
    }
}
