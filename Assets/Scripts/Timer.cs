using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    public float time = 300;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        float mins = Mathf.FloorToInt(time / 60);
        float secs = Mathf.FloorToInt(time - (mins*60));

        textMesh.text = $"{mins.ToString("00")}:{secs.ToString("00")}";
    }
}
