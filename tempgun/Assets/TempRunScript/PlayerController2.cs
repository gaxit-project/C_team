using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{

	public float tmpValue = 50.0f;
	public Animator anim;
	public float leftRightSpeed = 4f;
	public float limit = 1f;
	public AudioClip sound1;


	[SerializeField] private Transform _grandChild;

	private float nextTime;
	public float interval = 0.1f;   // 点滅周期

	Renderer renderComponent1;
	Renderer renderComponent2;
	Renderer renderComponent3;

	private bool flag = true;


	float axisH = 0.0f;
	public AudioSource audioSource2;









	void Start()
	{
		

		nextTime = Time.time;

		renderComponent1 = transform.Find("Body").gameObject.GetComponent<Renderer>();
		renderComponent2 = transform.Find("Face").gameObject.GetComponent<Renderer>();
		renderComponent3 = transform.Find("Hair").gameObject.GetComponent<Renderer>();


	}
	
	void Update()
	{
		anim.SetBool("jump", Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0));
		anim.SetBool("slide", Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton1));

		axisH = Input.GetAxisRaw("Horizontal");
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || axisH < 0.0f)
			{
				if (transform.position.x > -limit)
				{
					transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
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


	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "wall")
		{
				
			
			Destroy(other.gameObject);
			StartCoroutine(Blink());
			audioSource2.PlayOneShot(sound1);


		}
		
	}
	IEnumerator Blink()
	{

		if (flag)
		{
			for (int i = 0; i < 5; i++)
			{
				flag = false;
				renderComponent1.enabled = !renderComponent1.enabled;
				renderComponent2.enabled = !renderComponent2.enabled;
				renderComponent3.enabled = !renderComponent3.enabled;
				yield return new WaitForSeconds(0.1f);
				renderComponent1.enabled = !renderComponent1.enabled;
				renderComponent2.enabled = !renderComponent2.enabled;
				renderComponent3.enabled = !renderComponent3.enabled;
				yield return new WaitForSeconds(0.1f);


			}
			flag = true;
		}
		
	}

}
