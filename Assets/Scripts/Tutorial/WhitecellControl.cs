using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform whitecell;
    public Transform player;

    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(10, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (whitecell.position.x > player.position.x - 20)
            rb.velocity = new Vector2(5, 0);
        else
            rb.velocity = new Vector2(10, 0);
    }
}
