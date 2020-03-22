using UnityEngine;

// Helper class to invoke callback function
public class LevelControl : MonoBehaviour
{
    public void OnLevelSuccess()
    {
        GameStatus.OnLevelSuccess.Invoke();
    }

    public void OnLevelFail()
    {
        GameStatus.OnLevelFail.Invoke();
    }
}
