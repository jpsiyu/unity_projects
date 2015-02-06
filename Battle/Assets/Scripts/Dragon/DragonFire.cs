using UnityEngine;
using System.Collections;

public class DragonFire : MonoBehaviour {

	public ParticleSystem fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FireEvent(){
		fire.Play ();
	}

	public void FireEventEnd(){
		fire.Stop ();
	}
}
