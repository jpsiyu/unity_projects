using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKey ("a")) {
//			print ("a");			
//		}
//		if(Input.GetKey(KeyCode.A))
//			print("A");
//		if (Input.GetMouseButton (0)) {
//			print("mouse");		
//		}
		if (Input.GetButtonDown ("Fire1")) {
			print ("Fire1");		
		}
	}
	
}
