using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteaseSpawnerControl : MonoBehaviour
{
    [SerializeField] private float RespawnInterval = 2f;
    [SerializeField] private float ProteaseSpeed = 10;
    [SerializeField] private GameObject ProteasePrefab;
    private Vector2[] Vertexes;
    private float LastRespawnTime;
    void Start()
    {
        Vertexes = new Vector2[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
            Vertexes[i] = transform.GetChild(i).position;
        Respawn();
    }

    void Update()
    {
        if (Time.time - LastRespawnTime >= RespawnInterval)
            Respawn();
    }

    private void Respawn()
    {
        ProteaseControl NewProteaseControl = Instantiate<GameObject>(ProteasePrefab, transform).GetComponent<ProteaseControl>();
        NewProteaseControl.SetSpeed(ProteaseSpeed);
        NewProteaseControl.SetVertexes(Vertexes);
        NewProteaseControl.transform.position = transform.position;
        LastRespawnTime = Time.time;
    }
}
