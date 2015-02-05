using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform playerTransform;
	private float xDiff;
	

	// Use this for initialization
	void Start () {
		xDiff = this.transform.position.x - playerTransform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform == null)
						return;
		Vector3 pos = new Vector3 (playerTransform.position.x + xDiff, 
		                          this.transform.position.y,
		                          this.transform.position.z);
		transform.position = pos;
	}
}
