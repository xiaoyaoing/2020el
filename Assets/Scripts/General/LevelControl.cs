using UnityEngine;
using UnityEngine.SceneManagement;

// Helper class to invoke callback function
public class LevelControl : MonoBehaviour
{
    public void OnLevelSuccess()
    {
        SceneManager.LoadScene("WorldMap");
        SceneManager.sceneLoaded += (_, __) => GameStatus.OnLevelSuccess.Invoke();
    }

    public void OnLevelFail()
    {
        SceneManager.LoadScene("WorldMap");
        SceneManager.sceneLoaded += (_, __) => GameStatus.OnLevelFail.Invoke();
    }
}
