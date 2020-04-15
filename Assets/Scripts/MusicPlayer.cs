using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int musicPlayerCount = 0;
        foreach (var num in FindObjectsOfType<MusicPlayer>())
        {
            musicPlayerCount++;
        }

        if (musicPlayerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
