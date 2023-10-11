using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal : MonoBehaviour
{
    public string sceneName;


    //プレイヤーが当たり判定に入った時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ゴールしました！");

            SceneManager.LoadScene(sceneName);

        }
    }

}