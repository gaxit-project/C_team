//stage1シーンのScoreTextにアタッチ

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText; //得点の文字の変数
    [SerializeField]
    public static int minute;
    [SerializeField]
    public static float seconds;
    private float oldSeconds;
    bool ready = true;

    IEnumerator StartCall() //スタートしたらカウントダウンが終わるまで少し待つ
    {
        for (int i = 2; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        ready = false;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "stage1")　//シーンの名前がstage1かどうか
        {
            ScoreText.text = "";
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            ScoreText = GetComponentInChildren<Text>();
            StartCoroutine(StartCall()); //StartCallを呼ぶ
        }
    }

    void Update()
    {
        if (ready)
        {
            return;
        }
        if (GameManager.countdownSeconds > 0) //GameManagerのcountdownSecondsが0より多いか
        {
            seconds += Time.deltaTime;
        }
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        oldSeconds = seconds;

    }

}
