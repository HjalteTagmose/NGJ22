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

    public GameObject gameOverMenu;

    private void Start()
    {
        
    }

    public void GameOver(string msg)
    {
        gameOverMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        FindObjectOfType<StarterAssetsInputs>().Stop();
        
        var txt = gameOverMenu.transform.Find("title")?.GetComponent<TextMeshProUGUI>(); 
        if (txt) txt.text = msg;
    }

    public void Restart()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
