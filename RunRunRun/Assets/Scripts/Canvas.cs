using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Canvas : MonoBehaviour {

	int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text  = "Score: " + score;

		Invoke ("Restart", 3.0f);

	}

	void Restart(){
		Application.LoadLevel ("Main");
	}
}
