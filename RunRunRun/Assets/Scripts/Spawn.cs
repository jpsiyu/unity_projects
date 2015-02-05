using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject[] blocks;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBlocks", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnBlocks(){
		Instantiate(blocks[Random.Range(0,blocks.GetLength(0))], 
		            transform.position, 
		            Quaternion.identity);
	}
}
