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

	//モーション速度
	public float Speed = 1.5f;

	[SerializeField] private Transform _grandChild;

	private float nextTime;
	public float interval = 0.1f;   // 点滅周期

	Renderer renderComponent1;
	Renderer renderComponent2;
	Renderer renderComponent3;

	private bool flag = true;


	float axisH = 0.0f;
	public AudioSource audioSource2;


	//当たり判定
	[SerializeField] private CapsuleCollider CC;






	void Start()
	{
		

		nextTime = Time.time;

		renderComponent1 = transform.Find("Body").gameObject.GetComponent<Renderer>();
		renderComponent2 = transform.Find("Face").gameObject.GetComponent<Renderer>();
		renderComponent3 = transform.Find("Hair").gameObject.GetComponent<Renderer>();

		transform.Translate(0,0,0);
	}
	
	void Update()
	{

		axisH = Input.GetAxisRaw("Horizontal");

		//ダッシュ中
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

			transform.Translate(0, 0, 0);
			CC.center = new Vector3(0, 0.78f, 0);
			CC.direction = 1;

		}

		//スライディング中
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
		{
			CC.center = new Vector3(0, CC.radius, 0);
			CC.direction = 2;
		}




		/////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.W))
		{
			anim.SetFloat("speed", Speed++);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			anim.SetFloat("speed", Speed = 1.5f);
		}
		//////////////////////////////////////////
		/////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.X))
		{
			transform.Rotate(new Vector3(0, 90, 0));
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			transform.Rotate(new Vector3(0, -90, 0));
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			transform.Rotate(new Vector3(0, 180, 0));
		}
		///////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			anim.SetFloat("speed", Speed = 0);
		}
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
			anim.SetFloat("speed", Speed = 1.5f);
		}
		//////////////////////////////////////////
	}



	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "wall")
		{
				
			
			Destroy(other.gameObject);
			StartCoroutine(Blink());
			audioSource2.PlayOneShot(sound1);

			Speed = 0.1f;
		}
	}



    //離れたとき
	void OnCollisionExit(Collision other)
    {
		if (other.gameObject.tag == "acceleration")
		{
			anim.SetFloat("speed", Speed = 1.5f);
		}
	}


	//接している間
    void OnCollisionStay(Collision other)
    {
		//加速版
        if(other.gameObject.tag == "acceleration")
        {
			anim.SetFloat("speed", Speed = 10);
		}

		//減速版
		if (other.gameObject.tag == "deceleration")
		{
			anim.SetFloat("speed", Speed = 0.1f);
		}

		//地面
		if (other.gameObject.tag == "grand")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
			{
				anim.Play("Vaut");
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.JoystickButton0))
			{
				anim.Play("Slide");
			}
		}

		if (Speed < 1.5 - 0.05)
        {
			anim.SetFloat("speed", Speed += 0.05f);
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
