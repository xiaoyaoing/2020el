using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMControl : MonoBehaviour
{
    private Vector2 Force = new Vector2(0, 0.3f);
    private float TargetY;
    private Rigidbody2D PMRb;
    void Start()
    {
        PMRb = GetComponent<Rigidbody2D>();
        TargetY = PMRb.position.y - 1;
    }

    void Update()
    {
        PMRb.AddForce(Force * Mathf.Sign(TargetY - PMRb.position.y));
        PMRb.AddForce(-PMRb.velocity.x * new Vector2(0.5f, 0));
    }
}
