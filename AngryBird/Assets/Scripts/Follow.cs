using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform playerTransform;
	public float leftBoundary;
	public float rightBoundary;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position;
		float x = Mathf.Clamp (playerTransform.position.x,
		                      leftBoundary,
		                      rightBoundary);
		newPos.x = x;
		transform.position = newPos;

	}
}
