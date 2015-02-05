using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find ("Player");
		Vector3 player_pos = player.GetComponent<Transform> ().position;
		this.GetComponent<Transform> ().position =
			new Vector3 (player_pos.x-2.4f,
			            player_pos.y + 18.3f,
			            player_pos.z - 14.7f);
	}
}
