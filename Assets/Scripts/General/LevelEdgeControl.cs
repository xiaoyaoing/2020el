using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdgeControl : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            GameObject.Find("LevelControl").GetComponent<LevelControl>().OnLevelFail();
    }
}
