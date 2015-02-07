using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float spawnTimeInterval;
	public int totalGroups;
	public Transform[] spawnPoints;
	public GameObject enemy;
	public GameObject enemyHorseRider;
	public GameObject enemyDragon;
	public Vector3 riderPosOffset;
	public Vector3 dragonPosOffset;

	private int currentGroup;
	public int enemyCounter;

	// Use this for initialization
	void Start () {
		currentGroup = totalGroups;
		enemyCounter = 0;
		StartCoroutine (Spawn ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawn(){
		while(currentGroup > 0){

//			if(GameController.gameWin || GameController.gameOver)
//				break;	

			switch(GameController.level){
			case 0: LevelZeroSpawnStrategy(); break;
			case 1: LevelOneSpawnStrategy(); break;
			default: LevelTwoSpawnStrategy(); break;
			}

			currentGroup--;

			yield return new WaitForSeconds(spawnTimeInterval);
		}
	}

	// when in level 0
	void LevelZeroSpawnStrategy(){
		for (int i=0; i < spawnPoints.GetLength(0); i++) {
			Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
			enemyCounter ++;
		}
	}

	// when in level 1
	void LevelOneSpawnStrategy(){
		for (int i=0; i < spawnPoints.GetLength(0); i++) {
			if(Random.Range(1, 100) > 70)
				Instantiate(enemyHorseRider, spawnPoints[i].position + riderPosOffset, Quaternion.identity);		
			else
				Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
			enemyCounter ++;
		}
	}

	// when in level 2
	void LevelTwoSpawnStrategy(){
		for (int i=0; i < spawnPoints.GetLength(0); i++) {
			if(Random.Range(1, 100) > 70)
				Instantiate(enemyHorseRider, spawnPoints[i].position + riderPosOffset, Quaternion.identity);
			else if(Random.Range(1, 40) > 0)
				Instantiate(enemyDragon, spawnPoints[i].position + dragonPosOffset, Quaternion.identity);
			else
				Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
			enemyCounter ++;
		}
	}

	public bool IsEnemySpawnEnginStop(){
		return currentGroup == 0;
	}
}
