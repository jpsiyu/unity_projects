using UnityEngine;
using System.Collections;

public class WheelRunning : MonoBehaviour {

	private Vector3 newEulerAngles;

	public float turnSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		newEulerAngles = transform.eulerAngles;
		newEulerAngles.z = newEulerAngles.z - turnSpeed;

		transform.eulerAngles = newEulerAngles;

		//print (transform.eulerAngles);
	
	}
}
