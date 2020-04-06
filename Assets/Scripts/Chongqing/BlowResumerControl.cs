using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowResumerControl : BlowControler
{
    private void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            control.ResumeBreathe();
            gameObject.SetActive(false);
        }
    }
}
