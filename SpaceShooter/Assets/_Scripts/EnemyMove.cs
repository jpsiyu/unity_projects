using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed;

	public GameObject bolt;
	public Transform shotSpawn;

	public float nextFire;
	public float fireTime;

	void Start(){
		nextFire = 0.0f;
	}

	void FixedUpdate(){
		//rigidbody.velocity = transform.forward * speed;
	}

	public void Update(){
		if(Time.time > nextFire){
			nextFire = Time.time + fireTime;
			Instantiate (bolt, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
