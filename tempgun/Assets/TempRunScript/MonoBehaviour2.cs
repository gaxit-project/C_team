using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class menu2 : MonoBehaviour
{
	Button b1;
	Button b2;
	void Start()
	{
		
		b1 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		b2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		b1.Select();
	}

	
}