using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int scores;
	public static bool gameOver;

	public Text scoreText;
	public Text timeLeftText;
	public Text gameOverText;

	public float timeLeft;

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
		if(timeLeft >= 0)
			timeLeft -= Time.deltaTime;

		if(timeLeft <= 0){
			gameOver = true;
			gameOverText.gameObject.SetActive(true);
		}

		if (gameOver && Input.GetButtonDown ("Fire1")) {

			StartCoroutine( ResetGame());		
		}
	}

	void UpdateText(){
		scoreText.text = "Scores: " + scores;
		timeLeftText.text = "Time Left: " + Mathf.RoundToInt( timeLeft);
	}

	public static void AddScore(int s){
		scores += s;
	}
	public static void MinScore(int s){
		scores -= s;
	}

	IEnumerator ResetGame(){
		yield return new WaitForSeconds (3.0f);
		gameOver = false;
		scores = 0;
		gameOverText.gameObject.SetActive (false);

		Application.LoadLevel (Application.loadedLevel);
	}
}
