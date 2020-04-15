using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject deahtMenuUI;
    public static bool isDead = false;

    void Start()
    {

    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            try
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            catch
            {
                //do nothing
            }
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (health <= 1)
        {
            deahtMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
            return;
        }

        health--;
    }
}
