using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other){
		Instantiate (explosion, other.transform.position, Quaternion.identity);
		Destroy (other.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
