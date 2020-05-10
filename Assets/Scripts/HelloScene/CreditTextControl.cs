using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditTextControl : MonoBehaviour
{
    private Text CreditText;
    private float WaitTime = 2f;
    private float FadeoutTime = 1.5f;

    void Start()
    {
        CreditText = GetComponent<Text>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > WaitTime)
        {
            CreditText.color = new Color(CreditText.color.r, CreditText.color.g, CreditText.color.b, Math.Max(0f, CreditText.color.a - Time.deltaTime / FadeoutTime));
            if (CreditText.color.a <= 0f)
                UnityEngine.SceneManagement.SceneManager.LoadScene("HelloScene");
        }
    }
}
