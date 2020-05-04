using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRushControl : MonoBehaviour
{
    private int RNACount;

    Rigidbody2D PlayerRb;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && RNACount >= 2)
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.y);
            PlayerRb.velocity = new Vector2(10, PlayerRb.velocity.y);
            RNACount -= 2;
        }
    }

    public void CollectRNA()
    {
        RNACount++;
    }

    public int GetRNACount()
    {
        return RNACount;
    }
}
