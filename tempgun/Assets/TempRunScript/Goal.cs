using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal : MonoBehaviour
{
    public string sceneName;


    //�v���C���[�������蔻��ɓ��������̏���
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�S�[�����܂����I");

            SceneManager.LoadScene(sceneName);

        }
    }

}