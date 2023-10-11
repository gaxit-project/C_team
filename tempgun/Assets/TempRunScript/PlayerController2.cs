using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour {

	public float tmpValue = 50.0f;
	public Animator anim;
	public float leftRightSpeed = 4f;
	public float limit = 1f;
	public AudioClip sound1;

	AudioSource audioSource;
	public Slider slider;
	[SerializeField] private Transform _grandChild;

	private float nextTime;
	public float interval = 0.1f;   // 点滅周期

	Renderer renderComponent;

	private bool flag = true;


	float axisH = 0.0f;










	void Start()
	{
		//Componentを取得
		audioSource = GetComponent<AudioSource>();
		slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
		nextTime = Time.time;
		renderComponent = transform.Find("Teddy_Bear").gameObject.GetComponent<Renderer>();
		
		
	}
	void Update () {
        anim.SetBool("jump", Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.JoystickButton0));
        anim.SetBool("slide", Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton1));

		axisH = Input.GetAxisRaw("Horizontal");

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || axisH < 0.0f)
		{
			if (transform.position.x > -limit)
			{
				transform.Translate(Vector3.left * Time.deltaTime *  leftRightSpeed);
			}
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || axisH > 0.0f)
		{
			if (transform.position.x < limit)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
			}
		}
		


	}
	void OnTriggerEnter(Collider other)
	{
		if (flag)
		{
			if (other.gameObject.tag == "wall")
			{
				flag = false;
				audioSource.PlayOneShot(sound1);
				Destroy(other.gameObject);
				StartCoroutine(Blink());
				

			}
		}
	}
	IEnumerator Blink()
	{


		for (int i = 0; i < 5; i++)
		{
			renderComponent.enabled = !renderComponent.enabled;
			yield return new WaitForSeconds(0.1f);
			renderComponent.enabled = !renderComponent.enabled;
			yield return new WaitForSeconds(0.1f);


		}
		flag = true;
	}

}
