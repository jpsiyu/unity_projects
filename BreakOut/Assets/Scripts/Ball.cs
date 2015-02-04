using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float bollInitialVelocity;

	private Rigidbody rb;
	private bool inPlay;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Start(){
		inPlay = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !inPlay){
			transform.parent = null;
			inPlay = true;
			rb.isKinematic = false;
			rb.AddForce(bollInitialVelocity, bollInitialVelocity, 0f);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			audio.Play();	
		}
	}
}
