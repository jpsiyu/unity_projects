using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireTime;
	public float nextFire;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		rigidbody.velocity = speed * new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.position = new Vector3 
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f, 
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (new Vector3 (
			0.0f,
			0.0f,
			tilt * moveHorizontal
		));
	}

	void Update(){
		if (/*Input.GetMouseButtonDown (0) && */Time.time > nextFire) {
			nextFire = Time.time + fireTime;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);		
		}
	}
}
