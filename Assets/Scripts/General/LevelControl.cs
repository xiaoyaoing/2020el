using UnityEngine;
using UnityEngine.SceneManagement;

// Helper class to invoke callback function
public class LevelControl : MonoBehaviour
{
    public void OnLevelSuccess()
    {
        SceneManager.LoadScene("WorldMap");
        SceneManager.sceneLoaded += GameStatus.InvokeSuccess;
    }

    public void OnLevelFail()
    {
        SceneManager.LoadScene("WorldMap");
        SceneManager.sceneLoaded += GameStatus.InvokeFail;
    }
}
