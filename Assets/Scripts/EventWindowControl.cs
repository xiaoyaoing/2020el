using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public struct EventInformation
{
    public string Description;
    public Sprite Image;

    // Callback is invoked when confirm button is clicked
    public UnityAction CallBack;
}
public class EventWindowControl : MonoBehaviour
{
    private Transform EventWindowTr;
    private Text EventDescription;
    private Image EventImage;
    private Button ConfirmButton;
    private CanvasControl Canvas;

    void Start()
    {
        EventWindowTr = GetComponent<Transform>();
        EventDescription = EventWindowTr.Find("Text").GetComponent<Text>();
        EventImage = GetComponentInChildren<Image>();
        ConfirmButton = GetComponentInChildren<Button>();
        Canvas = GetComponentInParent<CanvasControl>();
        gameObject.SetActive(false);
    }

    public void ShowEvent(EventInformation Info)
    {
        EventDescription.text = Info.Description;
        EventImage.sprite = Info.Image;
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
