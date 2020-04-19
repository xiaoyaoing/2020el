using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class EventActions
{
    public static Dictionary<string, UnityAction> LevelSuccess = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { GameStatus.LevelSuccess(); GameStatus.EnableLevel("SE"); GameStatus.EnableLevel("NE"); GameStatus.EnableLevel("NW"); GameStatus.EnableLevel("SW"); },
        ["Xi'an"] = () => { GameStatus.LevelSuccess(); },
        ["Chongqing"] = () => { GameStatus.LevelSuccess(); },
        ["Beijing"] = () => { GameStatus.LevelSuccess(); },
        ["Guangzhou"] = () => { GameStatus.LevelSuccess(); },
        ["Sample"] = () => { GameStatus.LevelSuccess(); GameStatus.EnableLevel("SE"); GameStatus.EnableLevel("NE"); GameStatus.EnableLevel("NW"); GameStatus.EnableLevel("SW"); }
    };
    public static Dictionary<string, UnityAction> LevelFail = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { SceneManager.LoadScene("Wuhan"); },
        ["Xi'an"] = () => { GameStatus.LevelFail(); },
        ["Chongqing"] = () => { GameStatus.LevelFail(); },
        ["Beijing"] = () => { GameStatus.LevelFail(); },
        ["Guangzhou"] = () => { GameStatus.LevelFail(); },
        ["Sample"] = () => { SceneManager.LoadScene("Sample"); }
    };
}
