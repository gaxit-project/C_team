using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// "AudioSource"�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�A�^�b�`
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{
    public static ChangeSoundVolume instance;

    public Slider slider;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
        


    }




}