using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement.Set (Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		//rigidbody.MovePosition (rigidbody.position + movement);
		transform.position += movement;
	}
}
