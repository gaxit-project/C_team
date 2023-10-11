using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    public Slider slider;

    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    void Update()
    {
        // マウス左
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.PlayOneShot(sound1);
        }
    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        audioSource.volume = newSliderValue;
    }

}