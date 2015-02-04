using UnityEngine;
using System.Collections;

public class ColumnSpawn : MonoBehaviour {

	public GameObject col;
	public float spawnTime;
	public float randomUpDistance;

	private Transform tran;
	private Vector3 randomPosition;

	// Use this for initialization
	void Start () {
		tran = GetComponent<Transform> ();
		randomPosition = Vector3.zero;

		StartCoroutine (Spawn());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds(3.0f);
		while(!GameController.gameOver){
			randomPosition.Set(0f, Random.Range(0, randomUpDistance), 0f);
			Instantiate (col, tran.position+randomPosition, Quaternion.identity);
			yield return new WaitForSeconds(spawnTime);
		}
	}
}
