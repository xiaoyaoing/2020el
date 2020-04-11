using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteaseControl : MonoBehaviour
{
    private LevelControl Level;
    private Rigidbody2D ProteaseRb;
    private Vector2[] Vertexes;
    private int TargetIndex = 0;
    private float Speed = 10;
    void Start()
    {
        Level = GameObject.Find("LevelControl").GetComponent<LevelControl>();
        ProteaseRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float DeltaX = Vertexes[TargetIndex].x - transform.position.x;
        float DeltaY = Vertexes[TargetIndex].y - transform.position.y;
        float Distance = Mathf.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);
        ProteaseRb.velocity = new Vector2(Speed * DeltaX / Distance, Speed * DeltaY / Distance);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Level.OnLevelFail();
        else if (collision.CompareTag("ProteaseVertex"))
        {
            ++TargetIndex;
            if (TargetIndex == Vertexes.Length)
                Destroy(gameObject);
        }
    }

    public void SetVertexes(Vector2[] v)
    {
        Vertexes = v;
    }

    public void SetSpeed(float s)
    {
        Speed = s;
    }
}
