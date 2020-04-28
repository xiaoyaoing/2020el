using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusRotateControl : MonoBehaviour
{
    private LayerMask Ground;
    private CircleCollider2D PlayerCc;
    private Rigidbody2D PlayerRb;
    void Start()
    {
        Ground = LayerMask.GetMask("Ground");
        PlayerCc = GetComponentInParent<CircleCollider2D>();
        PlayerRb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (PlayerCc.IsTouchingLayers(Ground))
            transform.Rotate(new Vector3(0, 0, PlayerRb.velocity.x / PlayerCc.radius / 2 * -Mathf.Sign(PlayerRb.gravityScale)));
    }
}
