using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongqingLevelControl : LevelControl
{
    private PlayerTrapControl Player;
    private Rigidbody2D PlayerRb;
    private GameObject QTEPanel;
    private GameObject TrappedNet;

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

    private Rigidbody2D[] PMRbs;

    private AudioSource AudioPlayer;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponentInChildren<PlayerTrapControl>();
        PlayerRb = GameObject.Find("Player").GetComponentInChildren<Rigidbody2D>();
        QTEPanel = GameObject.Find("Canvas").transform.Find("QTE Hint").gameObject;
        AudioPlayer = GetComponent<AudioSource>();
        Transform PMs = GameObject.Find("PMs").transform;
        PMRbs = new Rigidbody2D[PMs.childCount];
        for (int i = 0; i < PMs.childCount; ++i)
            PMRbs[i] = PMs.GetChild(i).GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (IsInQTE) QTE();
        if (!BlowPaused || BlowOnce)
            Breathe();
    }
    public void StartQTE(GameObject Net)
    {
        IsInQTE = true;
        CurrentButtonIndex = 0;
        LastButtonPressedTime = Time.time;
        QTEPanel.SetActive(true);
        TrappedNet = Net;
    }
    public void ExitQTE()
    {
        IsInQTE = false;
        Player.Untrap();
        QTEPanel.SetActive(false);
        TrappedNet.SetActive(false);
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
        {
            if (!AudioPlayer.isPlaying)
                AudioPlayer.Play();
            PlayerRb.AddForce(new Vector2(-10, 0));
            for (int i = 0; i < PMRbs.Length; ++i)
                PMRbs[i].AddForce(new Vector2(-20, 0));
        }
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
