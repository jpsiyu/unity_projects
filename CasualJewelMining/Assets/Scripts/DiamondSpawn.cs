using UnityEngine;
using System.Collections;

public class DiamondSpawn : MonoBehaviour {
	

	public GameObject[] diamonds;
	public int spawnNum;
	public float spawnBoundaryX;
	public float spawnBoundaryZ;

	// Use this for initialization
	void Start () {
		SpawnDiamonds ();
	}

	void SpawnDiamonds(){
		for (int i=0; i < spawnNum; i++) {
			Instantiate(diamonds[Random.Range(0, diamonds.GetLength(0))],
			            GenSpawnPoint(),
			            Quaternion.identity);
		}
	}

	Vector3 GenSpawnPoint(){
		Vector3 point = transform.position;
		point.x = Random.Range (-spawnBoundaryX, spawnBoundaryX);
		point.z = Random.Range (point.z, spawnBoundaryZ + point.z);
		return point;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
