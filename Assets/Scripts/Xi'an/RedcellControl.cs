using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedcellControl : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed);
    }
}
