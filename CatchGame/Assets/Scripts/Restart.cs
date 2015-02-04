using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		GameController.ResetGame ();
		audio.Play();
		Application.LoadLevel (Application.loadedLevel);
	}
}
