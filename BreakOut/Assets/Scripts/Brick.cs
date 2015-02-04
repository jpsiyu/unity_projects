using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public GameObject brickParticle;
	AudioSource audio;

	void Awake(){
	}
	
	void OnCollisionEnter (Collision other)
	{
		Instantiate(brickParticle, transform.position, Quaternion.identity);
		GameManager.instance.DestroyBrick();
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
