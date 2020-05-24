using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloSceneControl : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown && Time.timeSinceLevelLoad >= 1.5f)
            UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
    }
}
