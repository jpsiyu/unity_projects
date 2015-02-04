using UnityEngine;
using System.Collections;

public class MoveCollider : MonoBehaviour {

	public float moveDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Scenery") {
			other.transform.position += new Vector3(moveDistance, 0.0f, 0.0f);			
		}

		if (other.tag == "Column") {
			Destroy(other.gameObject);		
		}
	}

}
