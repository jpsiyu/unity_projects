using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float spawnTimeInterval;
	public int totalGroups;
	public Transform[] spawnPoints;
	public GameObject enemy;
	public GameObject enemyHorseRider;
	public Vector3 riderPosOffset;

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

			for (int i=0; i < spawnPoints.GetLength(0); i++) {
				if(Random.Range(1, 100) > 70)
					Instantiate(enemyHorseRider, spawnPoints[i].position + riderPosOffset, Quaternion.identity);		
				else
					Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
				enemyCounter ++;
			}
			currentGroup--;

			yield return new WaitForSeconds(spawnTimeInterval);
		}
	}

	public bool IsEnemySpawnEnginStop(){
		return currentGroup == 0;
	}
}
