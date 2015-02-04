using UnityEngine;
using System.Collections;

public class HatScript : MonoBehaviour {

	private Camera cam;
	public float boundary;
	public float speed;
	Vector3 rawPosition;

	// Use this for initialization
	void Start () {
		if(cam == null)
			cam = Camera.main;

		rawPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void FixedUpdate(){
//		rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
//		rawPosition.Set (Mathf.Clamp(rawPosition.x, -boundary, boundary), 0.0f, 0.0f);
//		rigidbody2D.MovePosition (rawPosition);
//	}

	void FixedUpdate(){
		//float x = Mathf.Clamp (transform.position.x + Input.GetAxis ("Horizontal") * speed * Time.deltaTime, -boundary, boundary);
		float x = Mathf.Clamp (transform.position.x + Input.acceleration.x * speed * Time.deltaTime, -boundary, boundary);
		
		rawPosition.Set (x, 0.0f, 0.0f);
		
		rigidbody2D.MovePosition (rawPosition);
	}
}
