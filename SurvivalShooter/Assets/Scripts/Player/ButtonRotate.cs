using UnityEngine;
using System.Collections;

public class ButtonRotate: MonoBehaviour {

	public float turnSpeed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		EasyButton.On_ButtonDown += On_ButtonDown;	
		EasyButton.On_ButtonPress += On_ButtonPress;
		EasyButton.On_ButtonUp += On_ButtonUp;
	}
	
	void OnDisable(){
		EasyButton.On_ButtonDown -= On_ButtonDown;	
		EasyButton.On_ButtonPress -= On_ButtonPress;
		EasyButton.On_ButtonUp -= On_ButtonUp;		
	}
	
	void OnDestroy(){
		EasyButton.On_ButtonDown -= On_ButtonDown;	
		EasyButton.On_ButtonPress -= On_ButtonPress;
		EasyButton.On_ButtonUp -= On_ButtonUp;			
	}
	
	void On_ButtonDown( string buttonName){

	}
	
	void On_ButtonPress( string buttonName){
		float ts = 0f;
		if (buttonName == "TurnLeftButton")
			ts = turnSpeed;
		if (buttonName == "TurnRightButton")
			ts = -turnSpeed;
		transform.Rotate(Vector3.up, ts * Time.deltaTime);

	}
	
	void On_ButtonUp( string buttonName){}
}
