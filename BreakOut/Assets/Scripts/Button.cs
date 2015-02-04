using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public float paddleSpeed;
	public float bundaryX;

	private Vector3 playerPos = new Vector3(0f, 1.0f, 0f);

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
	
	void On_ButtonDown( string buttonName){}
	
	void On_ButtonPress( string buttonName){
		float direction = 0.0f;
		if(buttonName == "Left")
			direction = 1.0f;
		else if(buttonName == "Right"){
			direction = -1.0f;
		}
		float xPos = transform.position.x + direction * paddleSpeed * Time.deltaTime;
		playerPos = new Vector3(Mathf.Clamp(xPos, -bundaryX, bundaryX), transform.position.y,0f);
		transform.position = playerPos;
	}
	
	void On_ButtonUp( string buttonName){}
}
