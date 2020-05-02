using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject bubble;
    [SerializeField]
    Transform playerTransform;

    float t;

    void Generate()
    {
        float x = Random.Range(playerTransform.position.x , playerTransform.position.x + 100);
        float y = playerTransform.position.y - 40;
        Instantiate(bubble,new Vector3(x,y,0),Quaternion.identity);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t >= 0.5)
        {
            Generate();
            t = 0;
        }
    }
}
