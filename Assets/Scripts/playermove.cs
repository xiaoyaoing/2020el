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
    public bool is_touching_ground = false;
    public LayerMask ground;
    public Collider2D coll;
    private bool Trapped = false;

    void Start()
    {
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

        rb.AddForce(new Vector2(5, 0));
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
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
        rb.WakeUp();
    }

}
