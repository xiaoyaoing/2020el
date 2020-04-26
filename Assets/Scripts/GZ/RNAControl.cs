using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNAControl : MonoBehaviour
{
    private PlayerRushControl Player;
    private bool Collected = false;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerRushControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !Collected)
        {
            Player.CollectRNA();
            Collected = true;
            Destroy(gameObject);
        }
    }
}
