using UnityEngine;
using System.Collections;

public class MinerGun : MonoBehaviour {

	public float rayDistance;
	public GameObject claw;

	private RaycastHit hit;
	private bool isRayOut;

	// Use this for initialization
	void Start () {
		isRayOut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && !isRayOut && !GameController.gameOver) {
			GetTargetPositionByRay();		
		}
	}

	void GetTargetPositionByRay(){
		isRayOut = true;
		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance)) {
			claw.GetComponent<Claw>().UpdateTargetPosition(hit.point);
			//print (hit.point);
			claw.SetActive(true);
		}
	}
	

	public void PrepareRayOut(){
		isRayOut = false;
	}
}
