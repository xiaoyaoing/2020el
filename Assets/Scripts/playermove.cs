using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MaxHorizontalSpeed = 10;
    public float MaxVerticalSpeed = 10;
    private float GravityScale = 10;
    private BoxCollider2D JumpBox;
    public bool is_touching_ground = false;
    public LayerMask ground;
    public Collider2D coll;
    private bool Trapped = false;
    private float ImmuneUntil;
    public Transform CellPos;
    public bool IsInfecting;

    void Start()
    {
        JumpBox = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        move();
    }
    void move()
    {
        if (Trapped)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        else if (IsInfecting)
        {
            float DeltaX = CellPos.position.x - transform.position.x;
            float DeltaY = CellPos.position.y - transform.position.y;
            float Distance = Mathf.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);
            rb.velocity = new Vector2(DeltaX / Distance, DeltaY / Distance);
            return;
        }

        rb.AddForce(new Vector2(5, 0));
        if (Input.GetButtonDown("Jump") && JumpBox.IsTouchingLayers(ground))
            GravityScale = -GravityScale;
        rb.gravityScale = GravityScale;
        if (Mathf.Abs(rb.velocity.x) > MaxHorizontalSpeed)
            rb.velocity = new Vector2(MaxHorizontalSpeed * rb.velocity.x / Mathf.Abs(rb.velocity.x), rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > MaxVerticalSpeed)
            rb.velocity = new Vector2(rb.velocity.x, MaxVerticalSpeed * rb.velocity.y / Mathf.Abs(rb.velocity.y));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "white cell")
            Destroy(coll.gameObject);

    }

    public void Trap()
    {
        Trapped = true;
        rb.Sleep();
    }

    public void Untrap()
    {
        Trapped = false;
        SetImmue();
        rb.WakeUp();
        rb.velocity = new Vector2(MaxHorizontalSpeed, MaxVerticalSpeed * GravityScale / Mathf.Abs(GravityScale));
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
}
