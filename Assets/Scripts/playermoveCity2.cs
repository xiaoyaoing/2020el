using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermoveCity2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float x_speed = 10;
    private int label = -1;
    public bool is_touching_ground = false;
    public float y_speed = 10;
    public LayerMask ground;
    public Collider2D coll;
    public int Num_of_kangti = 0;
    public Text healthnumber, speed;
    public double health;

    void Start()
    {
        health = 100;
        rb.velocity = new Vector2(10, -10);
    }


    void Update()
    {
        if (Num_of_kangti >= 2)
        {
            Destroy(coll.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        move();

    }
    void move()
    {
        health -= 0.005;
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)) label = -label;
        rb.velocity = new Vector2(10 - 2 * Num_of_kangti, y_speed * label);
        transform.localScale = new Vector3(1, -label, 1);
        healthnumber.text = Num_of_kangti.ToString();
        speed.text = (10 - Num_of_kangti * 2).ToString();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "kangti")
        {
            Num_of_kangti += 1;
            Destroy(other.gameObject);
        }
        //if (other.tag == "deadline")
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }
}

