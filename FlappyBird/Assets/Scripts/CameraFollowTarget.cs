using UnityEngine;
using System.Collections;

public class CameraFollowTarget : MonoBehaviour {

	public Transform target;


	private float followDistance;

	private Transform tran;

	// Use this for initialization
	void Start () {
		tran = GetComponent<Transform> ();
		followDistance = tran.position.x - target.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		tran.position = new Vector3 (target.position.x + followDistance,
		                             tran.position.y, tran.position.z);
	}
}
