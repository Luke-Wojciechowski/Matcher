using System.Collections;
using System.Collections.Generic;
using Ingame;
using Source.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    [field: Min(0)] private int level = 0;
    
    public int Level => level;

    public void GoToNextLevel()
    {
        level += 1;
        var index = level < SceneManager.sceneCountInBuildSettings - 1
            ? level
            : level % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(index);
    }

    public void GoToMenu()
    {
        level = 0;
        SceneManager.LoadScene(level);
    }
}
