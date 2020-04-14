using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int damage = 1;
    void OnTriggerEnter(Collider other)
    {
        print("Hit");
        health -= damage;
        if (health <= 0)
        {
            print("DEAD");
        }
    }
}
