using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameDifficultyHard = false;
    public static bool gameDifficultyMedium = false;
    public static bool gameDifficultyEasy = false;
    public void PlayGameEasy()
    {
        SceneManager.LoadScene("GameEasy");
        gameDifficultyEasy = true;
    }

    public void PlayGameMedium()
    {
        SceneManager.LoadScene("GameMedium");
        gameDifficultyMedium = true;
    }

    public void PlayGameHard()
    {
        SceneManager.LoadScene("GameHard");
        gameDifficultyHard = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
