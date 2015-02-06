using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform player;

	private float posDiff;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		posDiff = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		pos.Set (player.position.x + posDiff, transform.position.y, transform.position.z);
		transform.position = pos;
	}
}
