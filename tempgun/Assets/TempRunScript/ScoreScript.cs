using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����

public class ScoreScript : MonoBehaviour
{
    private int Score; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    private float oldSeconds;
    bool ready = true;
    //private Text timerText;

    IEnumerator StartCall() // �R���[�`���̒ǋL
    {
        for (int i = 2; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        ready = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "";
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        ScoreText = GetComponentInChildren<Text>();
        StartCoroutine(StartCall());
    }



    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            return;
        }
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        if ((int)seconds != (int)oldSeconds)
        {
            ScoreText.text = "SCORE " + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

    }
}
