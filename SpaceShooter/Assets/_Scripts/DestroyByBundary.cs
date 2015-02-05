using UnityEngine;
using System.Collections;

public class DestroyByBundary : MonoBehaviour {
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
