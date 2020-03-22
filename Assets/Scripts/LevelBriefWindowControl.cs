using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct LevelInformation
{
    public Sprite Image;
    public string Description;
    public string SceneName;
    public string RegionName;
}

public class LevelBriefWindowControl : MonoBehaviour
{
    private Transform BriefTr;
    private Text LevelDiscription;
    private Image LevelImage;
    private Button StartButton;
    private CanvasControl Canvas;

    void Start()
    {
        BriefTr = GetComponent<Transform>();
        LevelDiscription = BriefTr.Find("Text").gameObject.GetComponent<Text>();
        LevelImage = BriefTr.Find("Image").gameObject.GetComponent<Image>();
        StartButton = GetComponentInChildren<Button>();
        Canvas = GetComponentInParent<CanvasControl>();
        gameObject.SetActive(false);
    }

    public void DisplayLevel(LevelInformation Info)
    {
        LevelDiscription.text = Info.Description;
        LevelImage.sprite = Info.Image;
        StartButton.onClick.AddListener(() => StartLevel(Info.RegionName, Info.SceneName));
        gameObject.SetActive(true);
        Canvas.DisableOtherWindows(gameObject);
    }

    public void StartLevel(string LevelRegionName, string LevelSceneName)
    {
        GameStatus.LevelStart(LevelRegionName);
        GameStatus.OnLevelSuccess = new UnityEngine.Events.UnityAction(() => ReturnToMap(true));
        GameStatus.OnLevelFail = new UnityEngine.Events.UnityAction(() => ReturnToMap(false));
        SceneManager.LoadScene(LevelSceneName);
    }

    // Callback used when level ends
    public void ReturnToMap(bool Success)
    {
        if (Success)
            GameStatus.LevelSuccess();
        else GameStatus.LevelFail();
        UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
    }
}
