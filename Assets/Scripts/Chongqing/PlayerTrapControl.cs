using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapControl : MonoBehaviour
{
    private float ImmuneUntil;
    private bool Trapped = false;
    private Rigidbody2D PlayerRb;
    private PlayerMoveControl Move;
    private SpriteRenderer PlayerImage;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        Move = GetComponent<PlayerMoveControl>();
        PlayerImage = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (IsImmue() && Time.time - Math.Floor(Time.time) < 0.5)
            PlayerImage.color = new Color(255, 255, 255, 0.5f);
        else PlayerImage.color = new Color(255, 255, 255);
    }

    public bool IsImmue()
    {
        return Time.time <= ImmuneUntil;
    }

    public void SetImmue()
    {
        ImmuneUntil = Time.time + 3f;
    }

    public void Trap()
    {
        Trapped = true;
        Move.enabled = false;
        PlayerRb.simulated = false;
    }

    public void Untrap()
    {
        Trapped = false;
        Move.enabled = true;
        PlayerRb.simulated = true;
        SetImmue();
        PlayerRb.velocity = new Vector2(Move.GetMaxHorizontalSpeed(), Move.GetMaxVerticalSpeed() * Mathf.Sign(Move.GetGravityScale()));
    }

    public bool IsTrapped() { return Trapped; }
}
