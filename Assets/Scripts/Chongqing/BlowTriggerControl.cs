using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTriggerControl : BlowControler
{
    private void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            control.TriggerBreathe();
            gameObject.SetActive(false);
        }
    }
}
