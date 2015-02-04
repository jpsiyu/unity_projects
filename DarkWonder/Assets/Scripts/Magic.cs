using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

	private float attack = 5.0f;

	private float liftTime = 5.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (destroy ());
	}
	
	// Update is called once per frame
	void Update () {
//		liftTime -= Time.deltaTime;
//		if (liftTime <= 0) {
//			GameObject.Destroy(this.gameObject);		
//		}
	}

	IEnumerator destroy(){
		yield return new WaitForSeconds (liftTime);
		GameObject.Destroy (this.gameObject);
	}

	void OnTriggerStay(Collider other){
		if (other.tag == ("Troll")) {
			other.gameObject.GetComponent<Troll>().health -= attack*Time.deltaTime;		
		}
	}
}
