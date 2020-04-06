using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D coll;
    private Transform PlayerTr, AntibodyTr;
    private bool label = false;
    public int x = 0;
    private PlayerControl Player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        PlayerTr = GameObject.Find("Player").transform;
        AntibodyTr = transform;
        Player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTr.position.x > AntibodyTr.position.x - 10)
            label = true;
        if (label)
            move();

    }

    void move()
    {
        rb.velocity = new Vector2(-3, 0);

        if (x % 300 == 0 && label)
            transform.position = new Vector3(transform.position.x, PlayerTr.position.y, transform.position.z);
        x++;
        //transform.position={x=transform.x,t.position}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.AttachAntibody();
            gameObject.SetActive(false);
        }
    }
}
