using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class CutsceneControl : MonoBehaviour
{
    private VideoPlayer Player;

    // Callback is invoked when cutscene ends
    private UnityAction CallBack;

    private CanvasControl Canvas;

    void Start()
    {
        Player = GetComponent<VideoPlayer>();
        Canvas = GetComponentInParent<CanvasControl>();
        gameObject.SetActive(false);
    }

    void ShowCutscene(VideoClip Video, UnityAction OnCutsceneEnd)
    {
        Player.clip = Video;
        Canvas.DisableOtherWindows(gameObject);
        gameObject.SetActive(true);
        Player.Play();
    }

    void Update()
    {
        if (!Player.isPlaying)
        {
            if (CallBack != null)
                CallBack.Invoke();
            CallBack = null;
            Canvas.RestoreDefault();
        }
    }
}
