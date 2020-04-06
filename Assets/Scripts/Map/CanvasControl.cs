using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    // Transform component is used to get childs of current object
    private Transform CanvasTr;

    void Start()
    {
        CanvasTr = GetComponent<Transform>();
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
