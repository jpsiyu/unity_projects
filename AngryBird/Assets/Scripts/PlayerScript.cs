using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Transform playerTransform;
	private bool canDray;
	private SpringJoint2D spring;

	public float drayRange;
	public LineRenderer frontLine;
	public LineRenderer backLine;

	public float maxDrayY;
	public float minDrayY;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
		spring = GetComponent<SpringJoint2D> ();
		canDray = false;
	}
	
	// Update is called once per frame
	void Update () {

		//print (playerTransform.position);

		if(canDray && spring)
			DrayPlayer ();

	}

	void DrayPlayer(){

		if(Input.touches.GetLength(0) == 0)
			return;
		Vector3 touchPosition = Camera.main.ScreenToWorldPoint (Input.touches [0].position);
		Vector3 targetPosition = touchPosition;

//		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//		Vector3 targetPosition = mousePosition;

		// reset reposition;
		targetPosition.Set (targetPosition.x, 
		                    Mathf.Clamp(targetPosition.y, minDrayY, maxDrayY),
		                   0f);

		Vector3 dis = targetPosition - playerTransform.position;

		//print (dis);
		//print (dis.sqrMagnitude + " " + drayRange * drayRange);

		if (dis.sqrMagnitude < drayRange * drayRange) {
			playerTransform.position = targetPosition;		
		}
	}

	void OnMouseDown(){
		canDray = true;
	}
	void OnMouseUp(){
		canDray = false;

		if(this.rigidbody2D.isKinematic)
			this.rigidbody2D.isKinematic = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (canDray) {
			return;		
		}
		if (other.tag == "CubeBoundary") {
			//print ("true");
			Destroy(spring);
			frontLine.enabled = false;
			backLine.enabled = false;
		}
	}

}
