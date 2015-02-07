using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject home;
	public GameObject enemySpawner;

	public static int enemyKilledCounter;
	public static bool gameOver;

	public Text gameStateText;
	public static bool gameWin;

	public bool isPassAllLevels;

	private bool gameResetFlag;

	public static int level;
	public int maxLevel;

	public Text levelText;

	// Use this for initialization
	void Start () {
		gameOver = false;
		gameWin = false;
		gameResetFlag = false;
		enemyKilledCounter = 0;

		// just do it one time at begining
		UpdateLevelText ();
		
	}
	
	// Update is called once per frame
	void Update () {

		CheckGameOver ();
		CheckGameWin ();
		GameReset ();
	}

	void CheckGameOver(){
		if(player.GetComponent<PlayerController>().isDead || home.GetComponent<Home>().isDead)
			gameOver = true;
		if(gameOver && !gameStateText.gameObject.activeInHierarchy){
			gameStateText.text = "Game Over";
			gameStateText.gameObject.SetActive(true);
		}
	}

	void CheckGameWin(){
		if(gameWin)
			return;

		if (enemySpawner.GetComponent<EnemySpawn> ().IsEnemySpawnEnginStop ()) {
			if(enemyKilledCounter == enemySpawner.GetComponent<EnemySpawn>().enemyCounter){
				gameWin = true;

				if(level == maxLevel)
					isPassAllLevels = true;

				if(level < maxLevel)
					level++;
			}
		}
		if(gameWin && !gameStateText.gameObject.activeInHierarchy){
			gameStateText.text = "Winner";
			gameStateText.gameObject.SetActive(true);
		}
	}

	void GameReset(){
		if(isPassAllLevels)
			return;

		if(!gameResetFlag &&  gameOver && Input.GetKeyDown(KeyCode.R)){
			gameResetFlag = true;
			Invoke("RestartGame", 1.0f);
		}
		if (!gameResetFlag && gameWin && (level <= maxLevel)) {
			gameResetFlag = true;
			Invoke("RestartGame", 2.0f);
		}
	}

	void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public static void AddEnemyKilled(){
		enemyKilledCounter++;
	}

	void UpdateLevelText(){
		levelText.text = "Lv: " + level;
	}
}
