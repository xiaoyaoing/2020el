using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPauserControl : BlowControler
{
    private void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            control.PauseBreathe();
            gameObject.SetActive(false);
        }
    }
}
