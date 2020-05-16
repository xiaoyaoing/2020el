using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintPanelControl : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
