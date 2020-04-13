using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public struct EventInformation
{
    public string Description;
    public Sprite Image;
    public string ButtonName;

    // Callback is invoked when confirm button is clicked
    public UnityAction CallBack;
}
public class EventWindowControl : MonoBehaviour
{
    private Transform EventWindowTr;
    private Text EventDescription;
    [SerializeField] private Image EventImage;
    private Button ConfirmButton;
    private CanvasControl Canvas;

    public UnityAction AfterStart;

    void Start()
    {
        EventWindowTr = GetComponent<Transform>();
        EventDescription = EventWindowTr.Find("Text").GetComponent<Text>();
        EventImage = EventWindowTr.Find("Image").gameObject.GetComponent<Image>();
        ConfirmButton = GetComponentInChildren<Button>();
        Canvas = GetComponentInParent<CanvasControl>();
        gameObject.SetActive(false);
        if (AfterStart != null)
            AfterStart.Invoke();
    }

    public void ShowEvent(EventInformation Info)
    {
        EventDescription.text = Info.Description;
        EventImage.sprite = Info.Image;
        ConfirmButton.GetComponentInChildren<Text>().text = Info.ButtonName;
        if (Info.CallBack != null)
            ConfirmButton.onClick.AddListener(Info.CallBack);
        ConfirmButton.onClick.AddListener(EventWindowCleanup);
        gameObject.SetActive(true);
        Canvas.DisableOtherWindows(gameObject);
    }

    // Clean up when confirm button is clicked
    public void EventWindowCleanup()
    {
        Canvas.RestoreDefault();
        ConfirmButton.onClick.RemoveAllListeners();
    }
}
