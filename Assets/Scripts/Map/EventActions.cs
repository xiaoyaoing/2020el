using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public static class EventActions
{
    public static EventInformation GameFail = new EventInformation
    {
        Description = "在疫情出现之后，全国各地迅速响应，启动公共卫生一级预案。在经历了前期的短暂爆发之后，国内疫情基本得到了控制。\n"
       + "然而，人们也没有因为这阶段性的成功而放松警惕，在全球疫情日益严重之时，各地抗疫的重心转向了防止境外病例的输入。\n"
       + "无论如何，这一场疫情必将给世界造成不可磨灭的影响......",
        CallBack = Application.Quit,
        ButtonName = "确定"
    };
    public static EventInformation GameSuccess = new EventInformation
    {
        Description = "病毒的来袭让人们猝不及防。武汉的感染人数迅速增加，接近十万人，其他地方也相继出现了疫情。\n"
        + "在疫情的传播逐渐超出控制范围之时，人们只剩下了一种选择。\n"
        + "一月二十二日，武汉市采取了史无前例的大规模封城措施。在这之后，全国各地也采取了类似的举措。\n"
        + "这场疫情让人们付出了巨大的代价，虽然目前多国疫情已经得到了基本控制，但它必将给这个世界不可磨灭的影响......",
        CallBack = Application.Quit,
        ButtonName = "确定"
    };
    public static UnityAction CheckGameEnd = () =>
    {
        if (GameStatus.GetLevelTriedCount() != 4) return;
        var Window = GameObject.Find("Canvas").transform.Find("Event Window").GetComponent<EventWindowControl>();
        if (GameStatus.GetLevelSuccessCount() >= 3)
            Window.ShowEvent(GameSuccess);
        else Window.ShowEvent(GameFail);
    };
    public static Dictionary<string, UnityAction> LevelSuccess = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { GameStatus.LevelSuccess(); GameStatus.EnableLevel("SE"); GameStatus.EnableLevel("NE"); GameStatus.EnableLevel("NW"); GameStatus.EnableLevel("SW"); },
        ["Xi'an"] = () => { GameStatus.LevelSuccess(); CheckGameEnd(); },
        ["Chongqing"] = () => { GameStatus.LevelSuccess(); CheckGameEnd(); },
        ["Beijing"] = () => { GameStatus.LevelSuccess(); CheckGameEnd(); },
        ["Guangzhou"] = () => { GameStatus.LevelSuccess(); CheckGameEnd(); },
        ["Sample"] = () => { GameStatus.LevelSuccess(); GameStatus.EnableLevel("SE"); GameStatus.EnableLevel("NE"); GameStatus.EnableLevel("NW"); GameStatus.EnableLevel("SW"); CheckGameEnd(); }
    };
    public static Dictionary<string, UnityAction> LevelFail = new Dictionary<string, UnityAction>
    {
        ["Wuhan"] = () => { SceneManager.LoadScene("Wuhan"); },
        ["Xi'an"] = () => { GameStatus.LevelFail(); CheckGameEnd(); },
        ["Chongqing"] = () => { GameStatus.LevelFail(); CheckGameEnd(); },
        ["Beijing"] = () => { GameStatus.LevelFail(); CheckGameEnd(); },
        ["Guangzhou"] = () => { GameStatus.LevelFail(); CheckGameEnd(); },
        ["Sample"] = () => { GameStatus.LevelFail(); CheckGameEnd(); }
    };
}
