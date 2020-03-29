using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermove : MonoBehaviour
{       
    public Rigidbody2D rb;
    public float x_speed=10;
    private int label=-1;
    public bool is_touching_ground=false;
    public float y_speed=10;
    public LayerMask ground;
    public Collider2D coll;
    public double health=100;
    public Text healthnumber;
    
    void Start()
    {   
        health=100;
        rb.velocity=new Vector2(10,-10);
    }

    
    void Update()  
    {   
      
       move();
       
    }
       void move(){
           health-=0.005;
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)) label=-label;
        rb.velocity=new Vector2(10,y_speed*label);
        transform.localScale=new Vector3(1,-label,1);
        healthnumber.text = health.ToString();
        
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "white cell")
        Destroy(coll.gameObject);
        
    }
    
}
