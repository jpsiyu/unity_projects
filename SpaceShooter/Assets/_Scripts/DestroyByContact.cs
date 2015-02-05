using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	public int newScoreValue;
	private GameController gameController;

	public void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameObject == null) {
			Debug.Log("can not find GameController scrip!");		
		}
	}

	public void OnTriggerEnter(Collider other){
//		print (other);
		if (other.tag == "Boundary") {
			return;		
		}

		Instantiate(explosion, transform.position, transform.rotation);
		if(other.tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		Destroy(other.gameObject);
		Destroy (gameObject);

		gameController.AddScore (newScoreValue);
	}	
}
