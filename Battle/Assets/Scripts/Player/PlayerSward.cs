using UnityEngine;
using System.Collections;

public class PlayerSward : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Enemy" && player.GetComponent<PlayerController>().IsAttacking()) {
			other.GetComponent<ArmyController>().LoseHealthy(1);		
		}
	}
}
