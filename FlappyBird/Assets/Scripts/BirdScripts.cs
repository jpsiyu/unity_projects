using UnityEngine;
using System.Collections;

public class BirdScripts : MonoBehaviour {

	public float speed;
	public float upForce;
	
	private Transform tran;
	private Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		tran = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.gameOver) {
			UpdatePosition();		
		}else{
			StopMove ();
		}
	}

	void UpdatePosition(){
		tran.position = tran.position + Vector3.right * speed * Time.deltaTime;
	}

	void StopMove(){
		rig.velocity.Set (0f, 0f);
	}

	void FixedUpdate(){
		if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown("Fire1")) && !GameController.gameOver) {
			rig.velocity = new Vector2(rig.velocity.x, 0.0f);
			rig.AddForce(new Vector2(0.0f, upForce));
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(GameController.gameOver)
			return;

		if(other.tag == "ColumnCross"){
			return;
		}

		GameController.gameOver = true;
		audio.Play ();
	}
}
