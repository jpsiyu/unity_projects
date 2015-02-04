using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public int age;
	private string name;
	public string pname; 

	public Transform cubeTransform;

	void Awake(){
		//print("awake");
		//print(this.transform.position);
		print (cubeTransform.transform.position);
	}

//	void Start(){
//		print ("start"); 
//	}
//
//	void Update(){
//		print("update");
//	}
//
//	void FixedUpdate(){
//		print ("Fixed Update");
//	}
}
