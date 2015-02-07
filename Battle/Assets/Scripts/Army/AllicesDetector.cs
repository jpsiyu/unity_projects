using UnityEngine;
using System.Collections;

public class AllicesDetector : MonoBehaviour {

	public GameObject parentObject;

	private GameObject attackTarget;
	private ArrayList attackTargets;

	// Use this for initialization
	void Start () {
		attackTargets = new ArrayList ();
	}
	
	// Update is called once per frame
	// Update is called once per frame
	void Update () {
		Attack ();
	}
	
	void Attack(){
		if (attackTargets == null)
			return;

		attackTarget = null;
		foreach (GameObject o in attackTargets) {
			if(o != null){	
				if(o.tag == "Enemy" && o.GetComponent<ArmyController>().isDead)
					continue;
				attackTarget = o;
			}
		}
		if(attackTarget == null){
			parentObject.GetComponent<ArmyController> ().UnDetected();
			return;
		}
		if(!parentObject.GetComponent<ArmyController>().IsAttacking())
			return;
		if(attackTarget.tag == "Enemy")
			attackTarget.GetComponent<ArmyController>().LoseHealthy(1);
		
	}
	
	// tell the army object do attack action
	void OnTriggerEnter(Collider other){

		// ok, player is our friend
		if(other.tag == "Enemy" ){
			parentObject.GetComponent<ArmyController> ().Detected ();
			attackTargets.Add(other.gameObject);
		}
	}

//	void OnTriggerExit(Collider other){
//		attackTargets.Remove(other.gameObject);
//	}

	
}
