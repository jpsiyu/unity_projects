using UnityEngine;
using System.Collections;

public class BikeMove : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public float jumpPower;
	public float jumpTime;

	private float turnAngle = 20;	
	private Vector3 jumpForce;
	private bool isJumpping;

	// Use this for initialization
	void Start () {
		isJumpping = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBikePosition ();


	}

	void FixedUpdate(){
		if(!isJumpping)
			BikeJump ();
	}

	void UpdateBikePosition(){
		Vector3 targetPosition = transform.position + transform.right * Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		transform.position = targetPosition;
		Vector3 targetEulerAngles =  transform.eulerAngles;
		targetEulerAngles.x = -Input.GetAxis ("Horizontal") * turnAngle;
		targetEulerAngles.y += Input.GetAxis ("Horizontal") * turnSpeed;
		transform.eulerAngles = targetEulerAngles;
	}

	void BikeJump(){
		if (Input.GetButtonDown ("Jump")) {
			isJumpping = true;
			jumpForce.Set(0.0f, jumpPower, 0.0f);
			rigidbody.AddForce(jumpForce);
			Invoke("DownForce", jumpTime);
		}
	}

	void DownForce(){
		isJumpping = false;
		jumpForce.Set(0.0f, -jumpPower*1.5f, 0.0f);
		rigidbody.AddForce(jumpForce);
	}
}
