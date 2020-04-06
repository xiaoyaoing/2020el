﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCellControl : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera VCam;
    PlayerControl Player;
    float CaptureTime = -1;
    void Start()
    {
        VCam = GameObject.Find("Camera").GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        Player = GameObject.Find("Player").GetComponentInChildren<PlayerControl>();
    }

    void Update()
    {
        if (CaptureTime > 0 && Time.time >= CaptureTime + 3f)
            GameObject.Find("LevelControl").GetComponent<LevelControl>().OnLevelSuccess();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CaptureTime = Time.time;
            Player.InfectCell(transform);
            GameObject Followee = new GameObject("_Followee");
            Followee.transform.position = Player.transform.Find("Followee").position;
            VCam.Follow = Followee.transform;
        }
    }
}
