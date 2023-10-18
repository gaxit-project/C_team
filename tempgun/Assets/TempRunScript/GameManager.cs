//stage1��GameManager�ɃA�^�b�`

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text timeCdText; //timeCdText��TimeCdText
    [SerializeField] Text callText; //callText��CallText
    bool ready = true;

    public static int countdownMinutes = 1; //�������ԁAGameManager��Countdown Minutes�Őݒ�
    public static float countdownSeconds; //1���Ԃ̕b���AStartCall�Őݒ�
    public float max;

    void Start()
    {
        timeCdText.text = "";
        StartCoroutine(StartCall()); //StartCall���Ă�
        max = GameManager.countdownMinutes * 60f;
    }

    //�X�^�[�g�̃J�E���g�_�E����\��
    IEnumerator StartCall() // �R���[�`���̒ǋL
    {
        countdownSeconds = countdownMinutes * 60; //1�������b�ɐݒ肷�邩

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

    //���Ԑ؂�ɂȂ�����GAME OVER��\�����ă��U���g��ʂɈړ�
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

        if (countdownSeconds <= 0) // ���Ԑ؂ꏈ���̒ǋL
        {
            ready = true;
            StartCoroutine(GameOver()); //GameOver���Ă�
        }
        else
        {
            countdownSeconds -= Time.deltaTime;
        }
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeCdText.text = span.ToString(@"mm\:ss");

    }
}
