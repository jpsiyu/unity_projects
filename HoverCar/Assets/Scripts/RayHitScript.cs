using UnityEngine;
using System.Collections;

public class RayHitScript : MonoBehaviour {

	public float rayLength;
	public float force;

	private Transform STransform;
	private Rigidbody SRigidbody;

	// Use this for initialization
	void Start () {
		STransform = GetComponent<Transform> ();
		SRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Ray ray = new Ray (STransform.position, -transform.up);
		//Ray ray = new Ray (STransform.position, Vector3.down);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, rayLength)){
			SRigidbody.AddRelativeForce(Vector3.up * force, ForceMode.Acceleration);
			//SRigidbody.AddForce(Vector3.up * force, ForceMode.Acceleration);

		}
	}
}
