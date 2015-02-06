using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Transform player;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){


		float z = Mathf.Rad2Deg *
				  Mathf.Atan2 (player.position.y - transform.position.y,
		                       player.position.x - transform.position.x) -
				  90;


//		this return rad, we have to change into degree
//		float z = Mathf.Atan2 (player.position.y - transform.position.y,
//		                       player.position.x - transform.position.z);

//		in our case, enemy is 90 degree to x, so we have to - 90 too
//		float z = Mathf.Atan2 (player.position.y - transform.position.y,
//		                       player.position.x - transform.position.z)
//							   * Mathf.Rad2Deg;

		//print (z);
		transform.eulerAngles = new Vector3 (0f, 0f, z);
		rigidbody2D.AddForce (gameObject.transform.up * speed);
	}
}
