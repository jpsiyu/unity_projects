using UnityEngine;
using System.Collections;

public class LightMove : MonoBehaviour {

	public Transform playerTransform;
	Vector3 positionDiff;
	public float lightSpeed;

	// Use this for initialization
	void Start () {
		positionDiff = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = playerTransform.position + positionDiff;
		transform.position = Vector3.Lerp (transform.position,
		                                  newPosition,
		                                  Time.deltaTime * lightSpeed);
	}
}
