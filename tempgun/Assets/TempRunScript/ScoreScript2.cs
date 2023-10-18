//resultシーンのScoreにアタッチ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript2 : MonoBehaviour
{
    public Text ScoreText;
    private int m;
    private int s;

    void Start()
    {
        m = ScoreScript.minute; //ScoreScriptのminuteを代入
        s = (int)ScoreScript.seconds; //ScoreScriptのsecondsをint型で代入;
        ScoreText = GetComponentInChildren<Text>(); //ScoreTextには何もD&Dしない
    }

    void Update()
    {
        ScoreText.text = "SCORE " + m.ToString("00") + ":" + s.ToString("00");　//リザルト画面でクリアタイムを表示
    }
}
