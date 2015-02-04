using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed;
	public float bundaryX;

	private Vector3 playerPos = new Vector3(0f, 1.0f, 0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + Input.GetAxis ("Horizontal") * paddleSpeed * Time.deltaTime;
		playerPos = new Vector3(Mathf.Clamp(xPos, -bundaryX, bundaryX), transform.position.y,0f);
		transform.position = playerPos;
	}
}
