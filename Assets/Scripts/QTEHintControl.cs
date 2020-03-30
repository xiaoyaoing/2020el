using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEHintControl : MonoBehaviour
{
    private Text HintText;
    private Color[] TextColors = { Color.black, Color.red };
    private float LastChangeTime;
    private float ChangeInterval = 0.5f;
    private int CurrentColorIndex = 0;
    void Start()
    {
        HintText = GetComponentInChildren<Text>();
        LastChangeTime = Time.time;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.time - LastChangeTime >= ChangeInterval)
        {
            CurrentColorIndex = (CurrentColorIndex + 1) % TextColors.Length;
            HintText.color = TextColors[CurrentColorIndex];
            LastChangeTime = Time.time;
        }
    }
}
