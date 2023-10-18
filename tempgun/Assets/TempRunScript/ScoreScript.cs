//stage1�V�[����ScoreText�ɃA�^�b�`

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

    IEnumerator StartCall() //�X�^�[�g������J�E���g�_�E�����I���܂ŏ����҂�
    {
        for (int i = 2; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        ready = false;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "stage1")�@//�V�[���̖��O��stage1���ǂ���
        {
            ScoreText.text = "";
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            ScoreText = GetComponentInChildren<Text>();
            StartCoroutine(StartCall()); //StartCall���Ă�
        }
    }

    void Update()
    {
        if (ready)
        {
            return;
        }
        if (GameManager.countdownSeconds > 0) //GameManager��countdownSeconds��0��葽����
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
