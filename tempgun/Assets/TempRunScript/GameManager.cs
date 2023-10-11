using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float playTime2;
    [SerializeField] Text timeCdText;
    [SerializeField] Text timeCuText;

    [SerializeField] Text callText; // �ǋL
    bool ready = true; // �ǋL
    [SerializeField] Text scoreText;

    public int countdownMinutes = 1;
    private float countdownSeconds;

    // Start is called before the first frame update
    void Start()
    {
        timeCdText.text = "";
        StartCoroutine(StartCall()); // �ǋL

    }

    IEnumerator StartCall() // �R���[�`���̒ǋL
    {
        countdownSeconds = countdownMinutes * 60;

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

    IEnumerator GameOver()
    {
        callText.text = "GAME OVER";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("result");
    }

    // Update is called once per frame
    void Update()
    {
        if (ready) // �ǋL
        {
            return;
        }

        if (countdownSeconds <= 0) // ���Ԑ؂ꏈ���̒ǋL
        {
            ready = true;
            StartCoroutine(GameOver());
        }

        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeCdText.text = span.ToString(@"mm\:ss");

    }

    public void OnClickClearBtn() // �{�^���ŌĂԊ֐��̒ǋL
    {
        ready = true;
        callText.text = "�N���A�I";
    }
}
