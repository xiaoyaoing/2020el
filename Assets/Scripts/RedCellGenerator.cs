using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCellGenerator : MonoBehaviour
{
    public GameObject redCell;
    public int cellNumber = 100;
    public Vector2 p1 = new Vector2(-50, -10), p2 = new Vector2(400, 20);

    void Start()
    {
        for (int i = 0; i < cellNumber; i++)
        {
            Instantiate(redCell, new Vector3(Random.Range(p1.x, p2.x), Random.Range(p1.y, p2.y), 0), Quaternion.identity);
        }
    }
    
}
