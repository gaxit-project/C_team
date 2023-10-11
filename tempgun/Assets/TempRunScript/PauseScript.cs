
using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{

	//　ポーズした時に表示するUI
	[SerializeField]
	private GameObject pauseUI;
	//　ゲーム再開ボタン
	[SerializeField]
	private GameObject reStartButton;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("q") || Input.GetKey(KeyCode.JoystickButton3))
		{

			Debug.Log("Q");
			//　ポーズUIが表示されてる時は停止
			if (!pauseUI.activeSelf)
			{
				//　ポーズUIのアクティブ、非アクティブを切り替え
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
