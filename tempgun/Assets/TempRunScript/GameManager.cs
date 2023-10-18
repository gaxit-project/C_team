//stage1のGameManagerにアタッチ

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text timeCdText; //timeCdText←TimeCdText
    [SerializeField] Text callText; //callText←CallText
    bool ready = true;

    public static int countdownMinutes = 1; //制限時間、GameManagerのCountdown Minutesで設定
    public static float countdownSeconds; //1分間の秒数、StartCallで設定
    public float max;

    void Start()
    {
        timeCdText.text = "";
        StartCoroutine(StartCall()); //StartCallを呼ぶ
        max = GameManager.countdownMinutes * 60f;
    }

    //スタートのカウントダウンを表示
    IEnumerator StartCall() // コルーチンの追記
    {
        countdownSeconds = countdownMinutes * 60; //1分を何秒に設定するか

        for (int i = 3; i > 0; i--)
        {
            callText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        callText.text = "GO!";
        ready = false;
        yield return new WaitForSeconds(1f);
        callText.text = "";
    }

    //時間切れになったらGAME OVERを表示してリザルト画面に移動
    IEnumerator GameOver()
    {
        callText.text = "GAME OVER";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("result");
        if (max < ScoreScript.seconds + ScoreScript.minute * 60)
        {
            ScoreScript.seconds = 0;
        }
    }

    void Update()
    {
        if (ready)
        {
            return;
        }

        if (countdownSeconds <= 0) // 時間切れ処理の追記
        {
            ready = true;
            StartCoroutine(GameOver()); //GameOverを呼ぶ
        }
        else
        {
            countdownSeconds -= Time.deltaTime;
        }
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeCdText.text = span.ToString(@"mm\:ss");

    }
}
