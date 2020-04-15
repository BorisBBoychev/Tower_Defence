using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
        MainMenu.gameDifficultyEasy = false;
        MainMenu.gameDifficultyMedium = false;
        MainMenu.gameDifficultyHard = false;
        Time.timeScale = 1f;
        PlayerHealth.isDead = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
