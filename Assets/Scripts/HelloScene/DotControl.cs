using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotControl : MonoBehaviour
{
    private float ChangeInterval;
    private bool Increasing = true;
    private Image DotImage;

    private static System.Random random = new System.Random();

    void Start()
    {
        ChangeInterval = (float)(1 + random.NextDouble());
        DotImage = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        float TargetAlpha = DotImage.color.a + (Increasing ? 1 : -1) * Time.fixedDeltaTime / ChangeInterval;
        if (TargetAlpha >= 1)
        {
            TargetAlpha = 1;
            Increasing = false;
        }
        else if (TargetAlpha <= 0)
        {
            TargetAlpha = 0;
            Increasing = true;
        }
        DotImage.color = new Color(DotImage.color.r, DotImage.color.g, DotImage.color.b, TargetAlpha);
    }
}
