using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (UnityEngine.Touch touch in Input.touches) {
			string msg = "";
			msg += "ID: " + touch.fingerId + "\n";
			//msg += "Phase: " + touch.phase.ToString + "\n";
			msg += "Count: " + touch.tapCount + "\n";
			msg += "Pos: " + touch.position.x + "," + touch.position.y;
			GUI.Label(new Rect (0 + 130, touch.fingerId, 120, 100), msg);
		}
	
	}
}
