using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnPosition;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	private int score;

	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	void Start(){
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine( SpawnWaves ());
	}

	void Update(){
		if (restart && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);	
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i=0; i<hazardCount; i++){
				Vector3 somePosition = new Vector3 (
					Random.Range(-spawnPosition.x, spawnPosition.x), 
					spawnPosition.y, 
					spawnPosition.z
				);
				Instantiate (hazard, somePosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver){
				restartText.text = "press R to restart the game!";
				restart = true;
				break;
			}
		}
	}

	void UpdateScore(){
		scoreText.text = "Scores: " + score;
	}

	public void AddScore(int num){
		score += num;
		UpdateScore ();
	}

	public void GameOver(){
		gameOverText.text = "GameOver!";
		gameOver = true;
	}
}
