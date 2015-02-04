using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private CharacterController controller;
	private int speed = 10;

	public bool canUseSkill = false;
	private float skillTimeLim = 2.0f;
	private float skillTimer;

	public GameObject prefab;

	public bool isNearTrex;
	public bool onTrex;
	private int needMeat;

	public bool canControl;
	public GameObject camera;

	public Trex trex;


	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController> ();
		skillTimer = skillTimeLim;
		isNearTrex = false;
		onTrex = false;
		needMeat = 5;
		canControl = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canControl) {
				
			skillTimer -= skillTimeLim;
			if (Input.GetButtonDown("Fire1") && skillTimer <= 0 && canUseSkill == true) {
				print("release skill");
				GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
				skillTimer = skillTimeLim;
			}
			else{
				//print ("skill time limit");
			}
			controller.SimpleMove(new Vector3(speed*Input.GetAxis ("Horizontal"),
			                                  0,
			                                  speed*Input.GetAxis ("Vertical")));
		}
		// change camera
		if(onTrex && Input.GetKeyDown(KeyCode.Q)){
			if(canControl){
				trex.GetControl();
				this.LoseControl();
			}else{
				trex.LoseControl();
				this.GetControl();
			}
		}
	}
	public void showDialog(){
		if (Meat.meatNum == 0) {
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 20), "kill dino and get meat!");		
		}else{
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 20), "feed dino with meat?");
			bool okButton = GUI.Button(new Rect(Screen.width/2, Screen.height/2+20, 50, 20), "ok");
			bool noButton = GUI.Button(new Rect(Screen.width/2+ 60, Screen.height/2+20, 50, 20), "no");
			if(okButton){

				if(Meat.meatNum - needMeat >= 0){
					Meat._instance.meatCount.text = Meat.meatNum - needMeat + "";
				}else{
					Meat._instance.meatCount.text = 0 + "";
				}

				needMeat -= Meat.meatNum;
				Meat.meatNum = 0;

				if(needMeat <= 0){
					onTrex = true;
					Message._instance.showMsg("dino will help you!", 3.0f);
				}
				isNearTrex = false;
			}
			if(noButton){
				isNearTrex = false;
			}
		}
	}
	public void OnGUI(){
		if (isNearTrex && !onTrex) {
			showDialog();		
		}
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Trex") {
			isNearTrex = true;	
		}
	}
	public void OnTriggerExit(Collider other){
		if (other.tag == "Trex") {
			isNearTrex = false;	
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
