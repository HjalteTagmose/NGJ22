using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public AK.Wwise.Event start;
    public AK.Wwise.Event stop;

    public Image background;
    public TextMeshProUGUI title;
    public GameObject buttons;

    Color titleColor;
    Color backgroundColor;

    void Start()
    {
        start.Post(gameObject);

        titleColor = title.color;
        backgroundColor = background.color;

        title.color = Color.clear;
        background.color = Color.clear;
        buttons.SetActive(false);
    }

    public void Open()
    {
        stop.Post(gameObject);
        Cursor.lockState = CursorLockMode.Confined;
        FindObjectOfType<StarterAssetsInputs>().Stop();

        StartCoroutine(FadeIn());
    }

    public void SetTitle(string msg)
    {
        title.text = msg.ToUpper();
    }

    IEnumerator FadeIn()
    {
        float a = 0;

        while (a < 1)
        {
            a += Time.deltaTime * 3;

            titleColor.a = a;
            backgroundColor.a = a;

            title.color = titleColor;
            background.color = backgroundColor;

            yield return null;
        
            if (a > 0.5f && !buttons.activeInHierarchy)
                buttons.SetActive(true);
        }
    }
}
