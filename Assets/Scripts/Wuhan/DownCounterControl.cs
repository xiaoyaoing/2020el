using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownCounterControl : MonoBehaviour
{
    [SerializeField] private float TotalTime;
    private float StopTime;
    private Text Counter;
    private LevelControl Level;
    void Start()
    {
        Counter = GetComponent<Text>();
        StopTime = TotalTime + Time.time;
        Level = GameObject.Find("LevelControl").GetComponent<LevelControl>();
    }

    void Update()
    {
        float RemainingTime = StopTime - Time.time;
        if (RemainingTime <= 0)
            Level.OnLevelFail();
        else
            Counter.text = string.Format("{0:D2}:{1:D2}:{2:D2}", Mathf.FloorToInt(RemainingTime / 60), Mathf.FloorToInt(RemainingTime % 60), Mathf.FloorToInt((RemainingTime - Mathf.FloorToInt(RemainingTime)) * 100));
    }
}
