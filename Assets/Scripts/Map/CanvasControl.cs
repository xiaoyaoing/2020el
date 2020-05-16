using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    // Transform component is used to get childs of current object
    private Transform CanvasTr;
    private EventWindowControl EvWin;

    void Start()
    {
        CanvasTr = GetComponent<Transform>();
        EvWin = GetComponentInChildren<EventWindowControl>();
    }

    private void Update()
    {
        if (!EvWin.gameObject.activeSelf && EvWin.Queued)
            EvWin.ShowEvent(EvWin.QueuedEvent);
    }

    public void DisableOtherWindows(GameObject ExceptWindow)
    {
        for (int i = 0; i < CanvasTr.childCount; ++i)
        {
            GameObject Window = CanvasTr.GetChild(i).gameObject;
            if (Window == ExceptWindow) continue;
            Window.SetActive(false);
        }
    }

    // By default, only navigation bar is enabled
    public void RestoreDefault()
    {
        for (int i = 0; i < CanvasTr.childCount; ++i)
        {
            GameObject Window = CanvasTr.GetChild(i).gameObject;
            if (Window.name == "Navigation Bar")
                Window.SetActive(true);
            else
                Window.SetActive(false);
        }
    }

}
