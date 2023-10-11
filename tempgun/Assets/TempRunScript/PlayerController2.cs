using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour {

	public float tmpValue = 50.0f;
	public Animator anim;
	public float leftRightSpeed = 4f;
	public float limit = 1f;
	public AudioClip sound1;

	AudioSource audioSource;
	public Slider slider;

	void Start()
	{
		//Componentを取得
		audioSource = GetComponent<AudioSource>();
		slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
	}
	void Update () {
        anim.SetBool("jump", Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.JoystickButton0));
        anim.SetBool("slide", Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton1));
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.position.x > -limit)
			{
				transform.Translate(Vector3.left * Time.deltaTime *  leftRightSpeed);
			}
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x < limit)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
			}
		}


	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "wall")
		{
			audioSource.PlayOneShot(sound1);
			Destroy(other.gameObject);
		}
	}

}
