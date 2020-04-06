using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapControl : MonoBehaviour
{
    private float ImmuneUntil;
    private bool Trapped = false;
    private Rigidbody2D PlayerRb;
    private PlayerMoveControl Move;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        Move = GetComponent<PlayerMoveControl>();
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
