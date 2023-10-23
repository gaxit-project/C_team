
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class PauseScript : MonoBehaviour
{
    Button b1;
    Button b2;
    Button b3;
    Slider bgm;
    Slider se;
    //�@�|�[�Y�������ɕ\������UI
    [SerializeField]
    private GameObject pauseUI;
    //�@�Q�[���ĊJ�{�^��
    [SerializeField]
    private GameObject reStartButton;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {

            Debug.Log("Q");
            //�@�|�[�YUI���\������Ă鎞�͒�~
            if (!pauseUI.activeSelf)
            {
                //�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
                pauseUI.SetActive(!pauseUI.activeSelf);
                Time.timeScale = 0f;
                Pause();



            }
            else
            {
                pauseUI.SetActive(!pauseUI.activeSelf);
                Time.timeScale = 1f;
            }
        }
    }

    public void ReStartGame()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        bgm = GameObject.Find("/Canvas/Panel/Slider_BGM").GetComponent<Slider>();
        se = GameObject.Find("/Canvas/Panel/Slider_SE").GetComponent<Slider>();
        b1 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        b2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        b3 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        // �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
        bgm.Select();
    }

}