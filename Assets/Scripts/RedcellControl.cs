using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedcellControl : MonoBehaviour

{
    private Transform PlayerTr, RedcellTr;
    private Rigidbody2D RedcellRb;
    private int speed = 5;
    private bool label = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTr = GameObject.Find("Player").transform;
        RedcellTr = transform;
        RedcellRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RedcellTr.position.x > PlayerTr.position.x + 10)
            label = true;
        if (label)
            RedcellRb.velocity = new Vector2(-speed, 0);

    }
}
