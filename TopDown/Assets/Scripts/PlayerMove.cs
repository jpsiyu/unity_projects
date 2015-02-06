using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();


//		print (transform.up);
//		print (Vector3.up);
//
//		print (transform.forward);
//		print (Vector3.forward);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger("Attack");		
		}
	
	}

	void FixedUpdate(){
		Vector3 mousePositon = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Vector3 mousePositon = Camera.ScreenToWorldPoint (Input.mousePosition);
		
		//Quaternion qu = Quaternion.LookRotation (transform.position, mousePositon);
		//Quaternion qu = Quaternion.LookRotation (mousePositon - transform.position, transform.forward);
		//Quaternion qu = Quaternion.LookRotation (mousePositon - transform.position);
		//Quaternion qu = Quaternion.LookRotation (mousePositon - transform.position, Vector3.forward);
		Quaternion qu = Quaternion.LookRotation (transform.position - mousePositon, Vector3.forward);
		
		transform.rotation = qu;
		//print (transform.eulerAngles.z);
		transform.eulerAngles = (new Vector3(0f, 0f, transform.eulerAngles.z));

		float input = Input.GetAxis ("Vertical");
		rigidbody2D.AddForce(gameObject.transform.up * speed * input);

		//print (transform.up);
	}
}
