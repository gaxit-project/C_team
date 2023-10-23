using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText; //���_�̕����̕ϐ�
    [SerializeField]
    public static int minute;
    [SerializeField]
    public static float seconds;
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
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            ScoreText.text = "";
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            ScoreText = GetComponentInChildren<Text>();
            StartCoroutine(StartCall());
        }
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
        oldSeconds = seconds;

    }

}
