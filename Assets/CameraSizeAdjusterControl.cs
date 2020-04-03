using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeAdjusterControl : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera VCam;
    [SerializeField] private float CameraSize;
    [SerializeField] private float TransitionTime;
    private float StartTime = -1;
    private float OrigionalSize;
    void Start()
    {
        VCam = GameObject.Find("Camera").GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
    }
    void Update()
    {
        if (StartTime > 0 && StartTime + TransitionTime >= Time.time)
            VCam.m_Lens.OrthographicSize = OrigionalSize + (CameraSize - OrigionalSize) * (Time.time - StartTime) / TransitionTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartTime = Time.time;
            OrigionalSize = VCam.m_Lens.OrthographicSize;
        }
    }
}
