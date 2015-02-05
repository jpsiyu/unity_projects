using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

	public int powerScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			GameController.AddPowerScore(powerScore);
			GameController.getPower = true;
			Destroy(this.gameObject);		
		}
	}

}
