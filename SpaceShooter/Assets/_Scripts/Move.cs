using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Vector3 moveMent;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		EasyJoystick.On_JoystickTouchStart += On_JoystickTouchStart;
		EasyJoystick.On_JoystickMoveStart += On_JoystickMoveStart;
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
		EasyJoystick.On_JoystickTouchUp += On_JoystickTouchUp;
		EasyJoystick.On_JoystickTap += On_JoystickTap;
		EasyJoystick.On_JoystickDoubleTap += On_JoystickDoubleTap;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickTouchStart -= On_JoystickTouchStart;
		EasyJoystick.On_JoystickMoveStart -= On_JoystickMoveStart;
		EasyJoystick.On_JoystickMove -= On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		EasyJoystick.On_JoystickTouchUp -= On_JoystickTouchUp;
		EasyJoystick.On_JoystickTap -= On_JoystickTap;
		EasyJoystick.On_JoystickDoubleTap -= On_JoystickDoubleTap;
	}
	
	void OnDestroy(){
		EasyJoystick.On_JoystickTouchStart -= On_JoystickTouchStart;
		EasyJoystick.On_JoystickMoveStart -= On_JoystickMoveStart;
		EasyJoystick.On_JoystickMove -= On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		EasyJoystick.On_JoystickTouchUp -= On_JoystickTouchUp;
		EasyJoystick.On_JoystickTap -= On_JoystickTap;
		EasyJoystick.On_JoystickDoubleTap -= On_JoystickDoubleTap;
	}	
	
	void On_JoystickDoubleTap (MovingJoystick move){}
	
	void On_JoystickTap (MovingJoystick move){}
	
	void On_JoystickTouchUp (MovingJoystick move){
	}
	
	void On_JoystickMoveEnd (MovingJoystick move){}
	
	void On_JoystickMove(MovingJoystick move){
		moveMent.Set (move.joystickAxis.x, 0.0f, move.joystickAxis.y);
		moveMent = moveMent.normalized * player.GetComponent<PlayerController> ().speed * Time.deltaTime;
		player.rigidbody.MovePosition(player.transform.position + moveMent);
	}
	
	void On_JoystickMoveStart (MovingJoystick move){}
	
	void On_JoystickTouchStart (MovingJoystick move){}
}
