using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigibody;
	int floorMask;
	float camRayLength = 100f; 



	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigibody = GetComponent<Rigidbody> ();
	}

//	void FixedUpdate(){
//		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw("Vertical");
//		Move(h,v);
//		//Turning ();
//		Animating (h, v);
//	}

	public void Move(float h, float v){
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigibody.MovePosition (transform.position + movement);
	}

	public void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigibody.MoveRotation(newRotation);
		}
	}





	public void Animating(float h, float v){
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
