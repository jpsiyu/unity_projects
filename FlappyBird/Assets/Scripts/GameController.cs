using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int scores;
	public static bool gameOver;
	public Text scoreText;
	public Text gameOverText;
	public Button restart;

	// Use this for initialization
	void Start () {
		scores = 0;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText();
		if (gameOver) {
			gameOverText.gameObject.SetActive(true);
			restart.gameObject.SetActive(true);
		}
	}

	public static void AddScores(int score){
		scores += score;
	}

	public static void MinScores(int score){
		scores -= score;
	}

	void UpdateText(){
		scoreText.text = "Scores: " + scores;
	}

	public  void Reset(){
		scores = 0;
		gameOverText.gameObject.SetActive (false);
		restart.gameObject.SetActive (false);
	}

}
