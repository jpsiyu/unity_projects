using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	private int i = 0;

	public Text winText;

	// Use this for initialization
	void Start () {
		winText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis("Vertical");
		// Debug.Log (hor);
		// Debug.Log (ver);
		this.rigidbody.AddForce (new Vector3 (hor, 0, ver) * 10f);
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Food"){
			Destroy(other.gameObject);
			i++;
			if (i >= 5){
				winText.gameObject.SetActive(true);
			}
		}
	}
}
