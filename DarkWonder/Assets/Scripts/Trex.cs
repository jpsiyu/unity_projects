using UnityEngine;
using System.Collections;

public class Trex : MonoBehaviour {

	private CharacterController controller;
	private float speed;
	public Animation anim;

	private string curFame;

	public GameObject helpTrigger;

	public bool canControl;

	public GameObject camera;


	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController> ();
		speed = 10.0f;
		canControl = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canControl){
			transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * 30 * Time.deltaTime, 0));
			controller.SimpleMove (transform.forward*speed*Input.GetAxis ("Vertical"));
			if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.1f) {
				if(curFame != "walk_loop"){
					this.anim.CrossFade("walk_loop");
					curFame = "walk_loop";
				}
			}else{
				if(curFame != "idle"){
					this.anim.CrossFade("idle");
					curFame = "idle";
				}
			}

			if (Input.GetButtonDown ("Fire1")) {
				anim.CrossFade("hit");	
	//			anim.CrossFade("Look_left");
	//			anim.CrossFade("Jump");
	//			anim.CrossFade("Dodge");
				//anim.CrossFadeQueued("Jump", 2.0f, QueueMode.CompleteOthers, PlayMode.StopAll);
			}
		}
	}

	public void OnTriggerStay(Collider other){
		if (other.gameObject.name == "HelpTrigger") {
			if (Input.GetButtonDown ("Fire1")){
				other.GetComponent<HelpTrigger>().destroyFences();
			}
		}
	}

	public void GetControl(){
		canControl = true;
		camera.SetActive (true);
	}
	public void LoseControl(){
		canControl = false;
		camera.SetActive (false);
	}
}
