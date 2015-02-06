using UnityEngine;
using System.Collections;

public class EnemyDetector : MonoBehaviour {

	public GameObject parentObject;

	private GameObject attackTarget;
	private ArrayList attackTargets;

	// Use this for initialization
	void Start () {
		attackTargets = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

	void Attack(){
		attackTarget = null;
		foreach (GameObject g in attackTargets) {
			if(g != null){
				if(g.tag == "Allices" && g.GetComponent<ArmyController>().isDead)
					continue;

				attackTarget = g;
			}
		}

		
		if(attackTarget == null){
			parentObject.GetComponent<ArmyController> ().UnDetected ();
			return;
		}
		if(!parentObject.GetComponent<ArmyController>().IsAttacking())
			return;
		if(attackTarget.tag == "Player")
			attackTarget.GetComponent<PlayerController>().PlayerAttackedByEnemy(1);
		if(attackTarget.tag == "Allices")
			attackTarget.GetComponent<ArmyController>().LoseHealthy(1);
		if(attackTarget.tag == "PlayerHome")
			attackTarget.GetComponent<Home>().HomeAttackedByEnemy(1);
			
	}


	// tell the army object do attack action
	void OnTriggerEnter(Collider other){

		// ok, player is our friend
		if(other.tag == "Allices" || other.tag == "Player" || other.tag == "PlayerHome"){
			parentObject.GetComponent<ArmyController> ().Detected ();

			attackTargets.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player")
			attackTargets.Remove(other.gameObject);
	}

}
