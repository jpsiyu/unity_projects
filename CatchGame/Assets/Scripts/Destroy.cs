using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public AudioSource audioBalling;
	public AudioSource audioBomb;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "BallingBall")
			other.gameObject.SetActive(false);

		if (other.tag == "Bomb")
			other.gameObject.SetActive(false);

		if(this.tag == "Player" && other.tag =="BallingBall"){
			GameController.AddScore(10);
			audioBalling.Play ();
		}

		if(this.tag == "Player" && other.tag =="Bomb"){
			GameController.MinScore(10);
			audioBomb.Play ();
		}

	}
}
