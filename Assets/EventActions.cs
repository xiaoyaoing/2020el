using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventActions : MonoBehaviour
{
    public Dictionary<string, UnityAction> LevelSuccess = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { GameStatus.LevelSuccess(); GameStatus.EnableLevel("SE"); GameStatus.EnableLevel("NE"); GameStatus.EnableLevel("NW"); GameStatus.EnableLevel("SW"); },
        ["Xi'an"] = () => { GameStatus.LevelSuccess(); },
        ["Chongqing"] = () => { GameStatus.LevelSuccess(); },
        ["Beijing"] = () => { GameStatus.LevelSuccess(); },
        ["Guangzhou"] = () => { GameStatus.LevelSuccess(); }
    };
    public Dictionary<string, UnityAction> LevelFail = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { SceneManager.LoadScene("Wuhan"); },
        ["Xi'an"] = () => { GameStatus.LevelFail(); },
        ["Chongqing"] = () => { GameStatus.LevelFail(); },
        ["Beijing"] = () => { GameStatus.LevelFail(); },
        ["Guangzhou"] = () => { GameStatus.LevelFail(); }
    }; 

    private EventWindowControl EventWindow;

    void Start()
    {
        EventWindow = GameObject.Find("Canvas").transform.Find("Event Window").GetComponent<EventWindowControl>();
    }
}
