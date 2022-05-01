using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameOverMenu menu;

    private void Start()
    {
        menu = FindObjectOfType<GameOverMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.titleColor= Color.gray;
            GameController.Instance.GameOver("You went to the wrong room");
        }
    }
}
