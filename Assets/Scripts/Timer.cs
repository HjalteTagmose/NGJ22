using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    public float totalTime = 300;

    [Header("Juice")]
    public float heartbeatBeatSize = 1.25f;
    public float heartbeatStartTime = 60f;
    public float minHeartbeatRate = 30;
    public float maxHeartbeatRate = 100;
    [Space(5)]
    public Color[] blend;

    private float heartbeatRate;
    private float heartbeatTime;
    private float time;

    private TextMeshProUGUI textMesh;
    private RectTransform rt;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        rt = GetComponent<RectTransform>();

        time = totalTime;
        heartbeatRate = minHeartbeatRate;
    }

    void Update()
    {
        UpdateTimer();
        UpdateColor();
        UpdateSize();
    }

    private void UpdateColor()
    {
        float timePrColor = totalTime / blend.Length;
        float b = time / timePrColor;
        int cur = Mathf.Clamp(Mathf.FloorToInt(b), 0, blend.Length-1);
        int nxt = cur == 0 ? 0 : cur - 1;

        float t = b - cur;
        textMesh.color = blend[cur].Blend(blend[nxt], t);
    }

    private void UpdateSize()
    {
        if (time < heartbeatStartTime)
        {
            float mult = Mathf.Lerp(rt.localScale.x, 1, Time.deltaTime * 6f);
            if (mult < 1) mult = 1;
            rt.localScale = Vector3.one * mult;

            heartbeatTime += Time.deltaTime;
            if (heartbeatTime >= heartbeatRate/60)
            {
                rt.localScale = Vector3.one * heartbeatBeatSize;
                heartbeatTime = 0;

                float t = (heartbeatStartTime - time) / heartbeatStartTime;
                heartbeatRate = Mathf.Lerp(maxHeartbeatRate, minHeartbeatRate, t);
            }
        }
    }

    private void UpdateTimer()
    {
        time -= Time.deltaTime;
        float mins = Mathf.FloorToInt(time / 60);
        float secs = Mathf.FloorToInt(time - (mins * 60));

        textMesh.text = $"{mins.ToString("00")}:{secs.ToString("00")}";

        if (time <= 0)
            TimeOut();
    }

    private void TimeOut()
    {
        time = float.MaxValue;
        textMesh.text = "00:00";
        GameController.Instance.GameOver("Time ran out!");
    }
}
