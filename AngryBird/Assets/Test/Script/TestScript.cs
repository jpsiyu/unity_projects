using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	private LineRenderer lr;
	private Transform thisCube;


	public Transform otherCube;



	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		thisCube = GetComponent<Transform> ();

		LineSetup ();
	}
	
	// Update is called once per frame
	void Update () {
		LineUpdate ();
	}

	void LineUpdate(){

	}

	void LineSetup(){
		lr.SetPosition (0, thisCube.position);
		lr.SetPosition (1, otherCube.position);

		// we want to use a line which can tanch the circle's end point, not mid point
	}
}
