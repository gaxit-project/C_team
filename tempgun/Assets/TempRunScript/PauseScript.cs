
using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{

	//�@�|�[�Y�������ɕ\������UI
	[SerializeField]
	private GameObject pauseUI;
	//�@�Q�[���ĊJ�{�^��
	[SerializeField]
	private GameObject reStartButton;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("q") || Input.GetKey(KeyCode.JoystickButton3))
		{

			Debug.Log("Q");
			//�@�|�[�YUI���\������Ă鎞�͒�~
			if (!pauseUI.activeSelf)
			{
				//�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
				pauseUI.SetActive(!pauseUI.activeSelf);
				Time.timeScale = 0f;
			}
		}
	}

	public void ReStartGame()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);
		Time.timeScale = 1f;
	}

}
