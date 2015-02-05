﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	

	public float speed;
	Vector3 movement;

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

		float h = move.joystickAxis.x;
		float v = move.joystickAxis.y;

		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		rigidbody.MovePosition (transform.position + movement);

		//this.GetComponent<PlayerMovement> ().Turning ();
		this.GetComponent<PlayerMovement> ().Animating (h, v);
	}
	
	void On_JoystickMoveStart (MovingJoystick move){}
	
	void On_JoystickTouchStart (MovingJoystick move){}
}