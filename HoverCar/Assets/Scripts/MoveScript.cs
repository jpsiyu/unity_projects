using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;

	private Rigidbody carRigidbody;


	// Use this for initialization
	void Start () {
		carRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;

		carRigidbody.AddRelativeForce (Vector3.forward * move);
		carRigidbody.AddRelativeTorque (new Vector3(0f, turn, 0f));

	}
}
