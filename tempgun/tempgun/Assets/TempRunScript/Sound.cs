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
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    void Update()
    {
        // �}�E�X��
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.PlayOneShot(sound1);
        }
    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // ���y�̉��ʂ��X���C�h�o�[�̒l�ɕύX
        audioSource.volume = newSliderValue;
    }

}