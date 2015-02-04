using UnityEngine;
using System.Collections;

public class TestMovingCollider : MonoBehaviour {

	public float offSet;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed, 0f, 0f) * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other);
		other.transform.position = new Vector3 (other.transform.position.x + offSet,
		                                       other.transform.position.y,
		                                       other.transform.position.z);
	}

	void OnTriggerEnter(Collider other){
		print (other);
		other.transform.position = new Vector3 (other.transform.position.x + offSet,
		                                        other.transform.position.y,
		                                        other.transform.position.z);
	}
}
