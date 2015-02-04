using UnityEngine;
using System.Collections;

public class BoxBoundary : MonoBehaviour {

	public Rigidbody2D playerRigidbody;
	public float stopSpeed;
	public float delayTime;

	private SpringJoint2D spring;

	// Use this for initialization
	void Start () {
		spring = playerRigidbody.GetComponent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerRigidbody.velocity.sqrMagnitude < stopSpeed*stopSpeed && spring == null) 
			ResetGame(delayTime);
	}

	void ResetGame(float delay){
		Invoke ("ResetGame", delay);
	}

	void ResetGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.rigidbody2D == playerRigidbody) {
			ResetGame(delayTime);		
		}
	}
}
