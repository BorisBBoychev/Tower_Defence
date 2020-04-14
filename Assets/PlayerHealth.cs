using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private Text healthText;

    void Start()
    {
        healthText.text = "HP:" + health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        print("Hit");
        health -= damage;
        healthText.text = "HP:" + health.ToString();
    }
}
