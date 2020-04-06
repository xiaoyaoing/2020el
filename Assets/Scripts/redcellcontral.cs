using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redcellcontral : MonoBehaviour

{
    public Transform t,t1;
    public Rigidbody2D rb;
    private int speed=5;
    private bool label=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t1.position.x>t.position.x+10)
        label=true;
        if(label)
        rb.velocity=new Vector2(-speed,0);
        
    }
}
