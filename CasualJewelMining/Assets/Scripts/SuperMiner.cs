using UnityEngine;
using System.Collections;

public class SuperMiner : MonoBehaviour {

	public float speed;

	public bool canMove;

	private Vector3 move;

	// Use this for initialization
	void Start () {
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			move.Set(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
			transform.position += move;
		}
	}


}
