using UnityEngine;
using System.Collections;

public class Miner : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameOver)
			StopAnimator();

		if (Input.GetButtonDown ("Fire1")) {
			StopAnimator();
		}
	}

	public void StopAnimator(){
		anim.speed = 0f;
	}
	public void StartAnimator(){
		anim.speed = 1f;
	}
}
