using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, Random.Range(5,10));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 40)
        {
            Destroy(gameObject);
        }
    }
}
