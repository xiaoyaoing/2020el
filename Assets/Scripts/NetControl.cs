using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetControl : MonoBehaviour
{
    private playermove Player;
    private ChongqingLevelControl LevelControl;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponentInChildren<playermove>();
        LevelControl = GameObject.Find("LevelControl").GetComponent<ChongqingLevelControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Trap();
            LevelControl.StartQTE();
        }
    }
}
