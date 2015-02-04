using UnityEngine;
using System.Collections;

public class HelpTrigger : MonoBehaviour {

	public GameObject fence1;
	public GameObject fence2;

	public bool isFenceDestroy;

	// Use this for initialization
	void Start () {
		isFenceDestroy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !isFenceDestroy) {
			Message._instance.showMsg("ask dino for help!", 3.0f);		
		}
	}

	public void destroyFences(){
		if (fence1) {
			isFenceDestroy = true;
			GameObject.Destroy (fence1.gameObject);	
		}else if(fence2){
			isFenceDestroy = true;
			GameObject.Destroy (fence2.gameObject);
		}
	}
}
