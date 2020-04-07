using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdgeControl : MonoBehaviour
{
    private Rigidbody2D Player;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Player.simulated)
            GameObject.Find("LevelControl").GetComponent<LevelControl>().OnLevelFail();
    }
}
