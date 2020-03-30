using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongqingLevelControl : LevelControl
{
    private playermove Player;
    private Rigidbody2D PlayerRb;
    private GameObject QTEPanel;

    private bool IsInQTE;

    private string[] QTEButtonSerial = { "Jump", "Jump", "Jump", "Jump", "Jump" };
    private float MinQTEButtonInterval = 0.1f;
    private float MaxQTEButtonInterval = 1;
    private int CurrentButtonIndex;
    private float LastButtonPressedTime;

    private float LastBlowTime;
    private float BlowInterval = 5f;
    private bool BlowPaused = true;
    private bool BlowOnce;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponentInChildren<playermove>();
        PlayerRb = GameObject.Find("Player").GetComponentInChildren<Rigidbody2D>();
        QTEPanel = GameObject.Find("Canvas").transform.Find("QTE Hint").gameObject;
    }
    void Update()
    {
        if (IsInQTE) QTE();
        if (!BlowPaused || BlowOnce)
            Breathe();
    }
    public void StartQTE()
    {
        IsInQTE = true;
        CurrentButtonIndex = 0;
        LastButtonPressedTime = Time.time;
        QTEPanel.SetActive(true);
    }
    public void ExitQTE()
    {
        IsInQTE = false;
        Player.Untrap();
        QTEPanel.SetActive(false);
    }
    private void QTE()
    {
        if (Input.GetButtonDown(QTEButtonSerial[CurrentButtonIndex]))
        {
            // Too quick
            if (Time.time - LastButtonPressedTime < MinQTEButtonInterval)
                OnLevelFail();
            else
            {
                ++CurrentButtonIndex;
                LastButtonPressedTime = Time.time;
                if (CurrentButtonIndex == QTEButtonSerial.Length)
                    ExitQTE();
            }
        }
        else if (Time.time - LastButtonPressedTime > MaxQTEButtonInterval)
            OnLevelFail();
    }

    private void Breathe()
    {
        if (Time.time - LastBlowTime <= 0.8f)
            PlayerRb.AddForce(new Vector2(-10, 0));
        if (Time.time - LastBlowTime >= BlowInterval)
        {
            LastBlowTime = Time.time;
            if (BlowOnce) BlowOnce = false;
        }
    }

    public void PauseBreathe()
    {
        BlowPaused = true;
        BlowOnce = false;
    }
    public void ResumeBreathe()
    {
        BlowPaused = false;
        BlowOnce = false;
        LastBlowTime = Time.time;
    }
    public void TriggerBreathe()
    {
        BlowOnce = true;
        LastBlowTime = Time.time;
    }
}
