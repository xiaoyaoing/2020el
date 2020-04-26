using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class numofnormalcellcontral : MonoBehaviour
{
    PlayerRushControl player;
    Text num;
    int time = 0;
    public GameObject knowledge;
    public Text question;
    bool is_pausing;
    string[] questions ={"1、佩戴以下哪种口罩可以防病毒？（ ）\n A.活性炭口罩 B.面纱口罩\n C.海绵口罩 D.KN95颗粒物防护口罩",
    "4、关于乘坐电梯，下面那个行为是不对的？（ ）\n A.必须戴好口罩，接触电梯按钮时可用纸巾等隔开\n B.尽量不在电梯间交流\n C.不要用手揉眼睛、触碰面部 \nD.低楼层在电梯和楼梯中选择乘坐电梯"
    ,"11、下面哪种动物不是冠状病毒常见的宿主？（ ）\n A.果子狸 B.蝙蝠 \nC.竹鼠 D.蚊子 ",
    "13、关于就医时的事项，以下说法不正确的是？（ ） \nA.出现发热咳嗽乏力等症状及时就医 \nB.主动告知医生近期的活动地点 \nC.主动告知医生接触过可疑或确诊病例 \nD.向医生隐瞒近期的活动路线和过往病史 "};
    void Start()
    {
        player = GameObject.Find("Player").GetComponentInChildren<PlayerRushControl>();
        num = GetComponent<Text>();
    }

    public void Update()
    {
        num.text = player.GetRNACount().ToString();
        if (!is_pausing)
            time++;
        if (time % 1500 == 0 && time <= 6000)
        {
            question.text = questions[time / 1500 - 1].ToString();
            knowledge.SetActive(true);
            Time.timeScale = 0;
            is_pausing = true;
        }

    }
    public void Continue()
    {
        knowledge.SetActive(false);
        Time.timeScale = 1;
        is_pausing = false;
    }
    public void end()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
