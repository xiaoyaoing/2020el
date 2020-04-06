using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntibodyCounterControl : MonoBehaviour
{
    Text Number;
    playermove Player;
    // Start is called before the first frame update
    void Start()
    {
        Number = GetComponent<Text>();
        Player = GameObject.Find("Player").GetComponentInChildren<playermove>();
    }

    // Update is called once per frame
    void Update()
    {
        Number.text = Player.GetAttachedAntibody().ToString();
    }
}
