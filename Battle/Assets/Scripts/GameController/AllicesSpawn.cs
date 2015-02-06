using UnityEngine;
using System.Collections;

public class AllicesSpawn : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject allices;
	public GameObject allicesHorseRider;
	public GameObject allicesDragon;
	public int allicesCostGold;
	public int allicesHorseRiderCostGold;
	public int allicesDragonCostGold;
	public Vector3 horseRiderPositionOffset;
	public Vector3 dragonPositionOffset;
	

	private int spawnCounter;

	// Use this for initialization
	void Start () {
		spawnCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameWin || GameController.gameOver)
			return;

		if(Input.GetKeyDown(KeyCode.I))
			SpawnAllices();
		if(Input.GetKeyDown(KeyCode.O))
			SpawnAllicesHorseRider();
		if(Input.GetKeyDown(KeyCode.P))
			SpawnAllicesDragon();
	}

	// allices spawn method
	void SpawnAllices(){
		if(spawnPoints.GetLength(0) == 0)
			return;

		if(GoldController.goldCounter < allicesCostGold)
			return;

		Instantiate(allices, 
		            spawnPoints[spawnCounter%spawnPoints.GetLength(0)].position, 
		            new Quaternion(0f, 180f, 0f, 0f));
		spawnCounter++;
		GoldController.MinGold (allicesCostGold);
	}

	// allices horse rider spawn method
	void SpawnAllicesHorseRider(){
		if(spawnPoints.GetLength(0) == 0)
			return;
		
		if(GoldController.goldCounter < allicesHorseRiderCostGold)
			return;
		
		Instantiate(allicesHorseRider, 
		            spawnPoints[spawnCounter%spawnPoints.GetLength(0)].position + horseRiderPositionOffset, 
		            new Quaternion(0f, 180f, 0f, 0f));
		spawnCounter++;
		GoldController.MinGold (allicesHorseRiderCostGold);
	}

	// allices dragon rider spawn method
	void SpawnAllicesDragon(){
		if(spawnPoints.GetLength(0) == 0)
			return;
		
		if(GoldController.goldCounter < allicesDragonCostGold)
			return;
		
		Instantiate(allicesDragon, 
		            spawnPoints[spawnCounter%spawnPoints.GetLength(0)].position + dragonPositionOffset, 
		            new Quaternion(0f, 180f, 0f, 0f));
		spawnCounter++;
		GoldController.MinGold (allicesDragonCostGold);
	}
}
