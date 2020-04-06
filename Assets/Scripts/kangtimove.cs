using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kangtimove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Collider2D coll;
    public Transform PlayerTr ,AntibodyTr;
    public bool label = false;
    public int x = 0;
    void Start()
    {

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
}
