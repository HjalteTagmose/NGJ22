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

    void Start()
    {
        start.Post(gameObject);

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
        title.text = msg;
    }

    IEnumerator FadeIn()
    {
        float a = 0;
        var titleColor = title.color;
        var backgroundColor = background.color;

        while (a < 1)
        {
            a += Time.deltaTime;

            titleColor.a = a;
            backgroundColor.a = a;

            title.color = titleColor;
            background.color = backgroundColor;

            yield return new WaitForSeconds(0.1f);
        
            if (a > 0.5f && !buttons.activeInHierarchy)
                buttons.SetActive(true);
        }
    }
}
