using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMoveControl : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private BoxCollider2D JumpBox;
    private LayerMask GroundMask;

    [SerializeField] private float PushingForce = 5;
    private float GravityScale = 10;
    private float MaxHorizontalSpeed = 10;
    private float MaxVerticalSpeed = 10;

    private bool IsInfecting;
    private Transform InfectCellPos;

    void Start()
    {
        JumpBox = GetComponent<BoxCollider2D>();
        PlayerRb = GetComponent<Rigidbody2D>();
        GroundMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (IsInfecting)
        {
            float DeltaX = InfectCellPos.position.x - transform.position.x;
            float DeltaY = InfectCellPos.position.y - transform.position.y;
            float Distance = Mathf.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);
            PlayerRb.velocity = new Vector2(DeltaX / Distance, DeltaY / Distance);
            return;
        }

        // Apply apporiate pushing force based player's currend speed to reduce glitch.
        if (MaxHorizontalSpeed - PlayerRb.velocity.x > Time.fixedDeltaTime * PushingForce / PlayerRb.mass)
            PlayerRb.AddForce(new Vector2(PushingForce, 0));
        else if (MaxHorizontalSpeed > PlayerRb.velocity.x)
            PlayerRb.AddForce(new Vector2((MaxHorizontalSpeed - PlayerRb.velocity.x) / Time.fixedDeltaTime * PlayerRb.mass, 0));

        if (Input.GetButtonDown("Jump") && JumpBox.IsTouchingLayers(GroundMask))
            GravityScale = -GravityScale;
        PlayerRb.gravityScale = GravityScale;
        if (Mathf.Abs(PlayerRb.velocity.x) > MaxHorizontalSpeed)
            PlayerRb.velocity = new Vector2(MaxHorizontalSpeed * PlayerRb.velocity.x / Mathf.Abs(PlayerRb.velocity.x), PlayerRb.velocity.y);
        if (Mathf.Abs(PlayerRb.velocity.y) > MaxVerticalSpeed)
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, MaxVerticalSpeed * PlayerRb.velocity.y / Mathf.Abs(PlayerRb.velocity.y));
    }

    public void InfectCell(Transform pos)
    {
        InfectCellPos = pos;
        IsInfecting = true;
    }

    public float GetMaxHorizontalSpeed() { return MaxHorizontalSpeed; }
    public void SetMaxHorizontalSpeed(float Speed) { MaxHorizontalSpeed = Speed; }
    public float GetMaxVerticalSpeed() { return MaxVerticalSpeed; }
    public void SetMaxVerticalSpeed(float Speed) { MaxVerticalSpeed = Speed; }
    public float GetGravityScale() { return GravityScale; }
    public void SetGravityScale(float Scale) { GravityScale = Scale; }
}
