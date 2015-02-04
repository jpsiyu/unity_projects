using UnityEngine;
using System.Collections;

public class TrollSpawn : MonoBehaviour {

	public GameObject prefab;
	private float spawnTime;
	private float timer;
	public static int trollNum;
	private int trollNumMax;

	// Use this for initialization
	void Start () {
		spawnTime = 5.0f;
		timer = spawnTime;
		trollNumMax = 20;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0 && trollNum < trollNumMax) {
			timer = spawnTime;
			trollNum++;
			GameObject.Instantiate (prefab, transform.position, Quaternion.identity);
		}
	}
}
