using UnityEngine;
using System.Collections;

public class LerpMove : MonoBehaviour {

	public Vector3 pointA;
	public Vector3 pointB;

	public Color colorA;
	public Color colorB;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PositionLerp ();
		ColorLerp ();
	}

	void PositionLerp(){
		Vector3 newPoint;
		if (Input.GetKey (KeyCode.A))
			newPoint = pointA;
		else if (Input.GetKey (KeyCode.D))
			newPoint = pointB;
		else
			newPoint = transform.position;
		transform.position =  Vector3.Lerp (transform.position, newPoint, Time.deltaTime*speed);

	}

	void ColorLerp(){
		Color newColor;
		if(Input.GetKey(KeyCode.A))
			newColor = colorA;
		else if(Input.GetKey(KeyCode.D))
			newColor = colorB;
		else
			newColor = light.color;
		light.color = Color.Lerp (light.color, newColor, Time.deltaTime*speed);
	}
}
