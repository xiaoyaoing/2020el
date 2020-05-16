using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public struct EventInformation
{
    public string Description;
    public Sprite Image;
    public string ButtonName;
    public AudioClip Audio;

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
    private AudioSource AudioPlayer;

    public UnityAction AfterStart;
    public EventInformation QueuedEvent;
    public bool Queued;

    void Start()
    {
        Queued = false;
        EventWindowTr = GetComponent<Transform>();
        EventDescription = EventWindowTr.Find("Text").GetComponent<Text>();
        EventImage = EventWindowTr.Find("Image").gameObject.GetComponent<Image>();
        ConfirmButton = GetComponentInChildren<Button>();
        Canvas = GetComponentInParent<CanvasControl>();
        gameObject.SetActive(false);
        AudioPlayer = GetComponent<AudioSource>();
        if (AfterStart != null)
            AfterStart.Invoke();
    }

    public void ShowEvent(EventInformation Info)
    {
        Queued = false;
        if (gameObject.activeSelf)
        {
            QueuedEvent = Info;
            Queued = true;
        }
        EventDescription.text = Info.Description;
        if (Info.Image)
        {
            EventImage.gameObject.SetActive(true);
            EventImage.sprite = Info.Image;
        }
        else
            EventImage.gameObject.SetActive(false);
        ConfirmButton.GetComponentInChildren<Text>().text = Info.ButtonName;
        if (Info.CallBack != null)
            ConfirmButton.onClick.AddListener(Info.CallBack);
        ConfirmButton.onClick.AddListener(EventWindowCleanup);
        gameObject.SetActive(true);
        AudioPlayer.clip = Info.Audio;
        if (Info.Audio)
            AudioPlayer.Play();
        Canvas.DisableOtherWindows(gameObject);
    }

    // Clean up when confirm button is clicked
    public void EventWindowCleanup()
    {
        Canvas.RestoreDefault();
        ConfirmButton.onClick.RemoveAllListeners();
    }
}
