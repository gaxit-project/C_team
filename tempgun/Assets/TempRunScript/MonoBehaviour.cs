using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class menu : MonoBehaviour
{
	Button cube;
	Button sphere;
	Button cylinder;
	Button cube2;
	Slider bgm;
	Slider se;
    void Start()
    {
		// �{�^���R���|�[�l���g�̎擾
		cube = GameObject.Find("/Canvas/Title_Panel/Button1").GetComponent<Button>();
		sphere = GameObject.Find("/Canvas/Title_Panel/Button2").GetComponent<Button>();
		cylinder = GameObject.Find("/Canvas/Title_Panel/Button3").GetComponent<Button>();
		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		cube.Select();
	}
    
	public void Opusion()
	{
		bgm = GameObject.Find("/Canvas/Panel/Slider_BGM").GetComponent<Slider>();
		se = GameObject.Find("/Canvas/Panel/Slider_SE").GetComponent<Slider>();
		cube2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		bgm.Select();
	}
	public void Taitol()
	{
		// �{�^���R���|�[�l���g�̎擾
		cube = GameObject.Find("/Canvas/Title_Panel/Button1").GetComponent<Button>();
		sphere = GameObject.Find("/Canvas/Title_Panel/Button2").GetComponent<Button>();
		cylinder = GameObject.Find("/Canvas/Title_Panel/Button3").GetComponent<Button>();
		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		cube.Select();
	}
}