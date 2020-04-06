using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowControler : MonoBehaviour
{
    protected ChongqingLevelControl control;

    protected void Init()
    {
        control = GameObject.Find("LevelControl").GetComponent<ChongqingLevelControl>();
    }

}
