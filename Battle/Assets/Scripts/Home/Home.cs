using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

	public int homeHealthy;
	public bool isDead;

	// Use this for initialization
	void Start () {
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (homeHealthy <= 0) {
			isDead = true;
			HomeDestroyed();		
		}
	}

	// home was destroyed by enemy
	void HomeDestroyed(){
		//Destroy (gameObject);
		gameObject.SetActive (false);
	}

	public void HomeAttackedByEnemy(int power){
		homeHealthy -= power;
	}
}
