using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private float MaxHorizontalSpeed = 10;
    private float MaxVerticalSpeed = 10;
    private float GravityScale = 10;
    private BoxCollider2D JumpBox;
    private LayerMask GroundMask;
    private bool Trapped = false;
    private float ImmuneUntil;
    private Transform CellPos;
    private bool IsInfecting;
    private int AntibodyAttached = 0;

    void Start()
    {
        JumpBox = GetComponent<BoxCollider2D>();
        PlayerRb = GetComponent<Rigidbody2D>();
        GroundMask = LayerMask.GetMask("Ground");
    }


    void Update()
    {
        move();
    }
    void move()
    {
        if (AntibodyAttached >= 3)
            return;
        if (Trapped)
        {
            PlayerRb.velocity = new Vector2(0, 0);
            return;
        }
        else if (IsInfecting)
        {
            float DeltaX = CellPos.position.x - transform.position.x;
            float DeltaY = CellPos.position.y - transform.position.y;
            float Distance = Mathf.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);
            PlayerRb.velocity = new Vector2(DeltaX / Distance, DeltaY / Distance);
            return;
        }

        PlayerRb.AddForce(new Vector2(5, 0));
        if (Input.GetButtonDown("Jump") && JumpBox.IsTouchingLayers(GroundMask))
            GravityScale = -GravityScale;
        PlayerRb.gravityScale = GravityScale;
        if (Mathf.Abs(PlayerRb.velocity.x) > MaxHorizontalSpeed)
            PlayerRb.velocity = new Vector2(MaxHorizontalSpeed * PlayerRb.velocity.x / Mathf.Abs(PlayerRb.velocity.x), PlayerRb.velocity.y);
        if (Mathf.Abs(PlayerRb.velocity.y) > MaxVerticalSpeed)
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, MaxVerticalSpeed * PlayerRb.velocity.y / Mathf.Abs(PlayerRb.velocity.y));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "white cell")
            Destroy(gameObject);

    }

    public void Trap()
    {
        Trapped = true;
        PlayerRb.Sleep();
    }

    public void Untrap()
    {
        Trapped = false;
        SetImmue();
        PlayerRb.WakeUp();
        PlayerRb.velocity = new Vector2(MaxHorizontalSpeed, MaxVerticalSpeed * GravityScale / Mathf.Abs(GravityScale));
    }

    public bool IsImmue()
    {
        return Time.time <= ImmuneUntil;
    }

    public void SetImmue()
    {
        ImmuneUntil = Time.time + 3f;
    }

    public void InfectCell(Transform pos)
    {
        CellPos = pos;
        IsInfecting = true;
    }

    public void AttachAntibody()
    {
        ++AntibodyAttached;
    }

    public int GetAttachedAntibody()
    {
        return AntibodyAttached;
    }
}
