using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_speed_ui_control : MonoBehaviour
{
    // Start is called before the first frame update
    Text Speed;
    
    PlayerAntibodyControl Player;
    void Start()
    {
        Speed = GetComponent<Text>();
        Player = GameObject.Find("Player").GetComponentInChildren<PlayerAntibodyControl>();}

    // Update is called once per frame
    void Update()
    {
        Speed.text= (10-2*Player.GetAttachedAntibodyCount()).ToString();
    }
}
