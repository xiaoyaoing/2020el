using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr1, sr2;
    int dir = -1;

    void Update()
    {
        float alpha = sr1.color.a + 0.001f * dir;
        if (alpha >= 1) dir = -1;
        if (alpha <= 0) dir = 1;
        sr1.color = new Color(1, 1, 1, alpha);
        sr2.color = new Color(1, 1, 1, 1 - alpha);
    }
}
