using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public TextMeshPro timerText;
    public bool isRunning = true;

    private float time;

    public float FinalTime => time;

    void Update()
    {
        if (!isRunning) return;

        time += Time.deltaTime;
        timerText.text = FormatTime(time);
    }

    string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60);
        int seconds = Mathf.FloorToInt(t % 60);
        int milliseconds = Mathf.FloorToInt((t * 1000) % 1000);
        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }
}
