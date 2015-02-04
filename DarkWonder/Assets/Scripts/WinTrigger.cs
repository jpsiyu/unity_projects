using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	private bool win;

	// Use this for initialization
	void Start () {
		win = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			win = true;
		}
	}
	public void OnGUI(){
		if (win) {
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 100), "you save the girl!");
			bool quitButton = GUI.Button(new Rect(Screen.width/2, Screen.height/2+30, 50, 20), "quit");
			if(quitButton){
				Application.Quit();
			}
		}
	}
}
