using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CityControl : MonoBehaviour
{
    private Transform CityTr;

    // Information of the corresponding level
    [SerializeField] private string LevelSceneName;
    [SerializeField] private string LevelRegionName;

    public EventInformation OnSelectCity;
    public EventInformation OnLevelSuccess;
    public EventInformation OnLevelFail;

    // Control component of the level brief window
    private EventWindowControl EventWindow;

    void Start()
    {
        CityTr = GetComponent<Transform>();
        EventWindow = GameObject.Find("Canvas").transform.Find("Event Window").gameObject.GetComponent<EventWindowControl>();
        OnSelectCity.CallBack = new UnityAction(() =>
        {
            SceneManager.LoadScene(LevelSceneName);
            GameStatus.LevelStart(LevelRegionName);
            GameStatus.OnLevelSuccess = () =>
            {
                EventWindowControl NewEventWindow = GameObject.Find("Canvas").transform.Find("Event Window").GetComponent<EventWindowControl>();
                NewEventWindow.AfterStart = new UnityAction(() => NewEventWindow.ShowEvent(OnLevelSuccess));
            };
            GameStatus.OnLevelFail = () =>
            {
                EventWindowControl NewEventWindow = GameObject.Find("Canvas").transform.Find("Event Window").GetComponent<EventWindowControl>();
                NewEventWindow.AfterStart = new UnityAction(() => NewEventWindow.ShowEvent(OnLevelFail));
            };
        });
        OnLevelSuccess.CallBack = new UnityAction(EventActions.LevelSuccess[LevelSceneName]);
        OnLevelFail.CallBack = new UnityAction(EventActions.LevelFail[LevelSceneName]);
    }

    // When selected, focus camera on current city, and show level brief
    public void Select()
    {
        // Disabled city could not be selectecd
        if (!GameStatus.GetRegionEnableStatus(LevelRegionName))
            return;

        var GameCam = Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        GameCam.Follow = CityTr;
        EventWindow.ShowEvent(OnSelectCity);
    }

    public string GetRegionName()
    {
        return LevelRegionName;
    }
}
