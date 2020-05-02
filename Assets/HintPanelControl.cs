using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintPanelControl : MonoBehaviour
{
    float SaveFixedDeltaTime;
    void Start()
    {
        Time.timeScale = 0;
        SaveFixedDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 1000;
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = SaveFixedDeltaTime;
        Destroy(gameObject);
    }
}
