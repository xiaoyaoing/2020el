using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainControl : MonoBehaviour
{
    private RawImage Curtain;
    private float FadeoutTime = 1.5f;

    void Start()
    {
        Curtain = GetComponent<RawImage>();       
    }

    void Update()
    {
        Curtain.color = new Color(Curtain.color.r, Curtain.color.g, Curtain.color.b, Math.Max(0f, Curtain.color.a - Time.deltaTime / FadeoutTime));   
    }
}
