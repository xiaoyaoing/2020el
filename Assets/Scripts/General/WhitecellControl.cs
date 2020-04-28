using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitecellControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform whitecell;
    private Transform PlayerTr;

    private bool Stopped;
    private float MaxSpeed;

    private LevelControl Level;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        PlayerTr = GameObject.Find("Player").transform;
        MaxSpeed = player.GetComponent<PlayerMoveControl>().GetMaxHorizontalSpeed();
        Level = GameObject.Find("LevelControl").GetComponent<LevelControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stopped)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        if (transform.position.x > PlayerTr.position.x - 20)
            rb.velocity = new Vector2(MaxSpeed / 2, 0);
        else
            rb.velocity = new Vector2(MaxSpeed, 0);
    }

    public void Stop()
    {
        Stopped = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Level.OnLevelFail();
    }
}
