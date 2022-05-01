using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }

    public GameOverMenu gameOverMenu;

    private void Start()
    {
        gameOverMenu = FindObjectOfType<GameOverMenu>();
    }

    public void GameOver(string msg)
    {
        print("gameOVERRR: " +msg);
        gameOverMenu.SetTitle(msg);
        gameOverMenu.Open();
    }

    public void Restart()
    {
        StopAllCoroutines();
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
