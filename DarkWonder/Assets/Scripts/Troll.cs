using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {
	private int state; // 0:idle; 1:move
	private float idleTime;
	private float moveTime;

	private float timer;
	private float speed = 2.0f;

	private Animator anim;
	private CharacterController controller;

	private float rotateAngle;

	public float health = 10;

	private bool startDestroy = false;
	private float destroyTimer = 2.0f;

	// Use this for initialization
	void Start () {
		state = 0;
		idleTime = 3.0f;
		moveTime = 5.0f;

		timer = idleTime;

		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			print("Troll death");
			die();
		}


		timer -= Time.deltaTime;
		// change state when timer <= 0
		if (timer <= 0 && state == 0) {
			// from idle to move
			timer = moveTime;
			state = 1;


			//transform.Rotate(new Vector3(0, Random.Range(-90, 90),0));
			rotateAngle = Random.Range(-90, 90);
			walkAnimation();

		}else if(timer <=0 && state == 1){
			// from move to idle
			timer = idleTime;
			state = 0;

			idleAnimation ();

		}else{
			// do rotation

		}
		// action
		if (state == 1) {
			//transform.position += transform.forward*Time.deltaTime*speed;
			rotate();
			controller.SimpleMove(transform.forward*speed);
		}

		// destroy timer 
		if (startDestroy) {
			destroyTimer -= Time.deltaTime;
			if(destroyTimer <= 0){
				GameObject.Destroy(this.gameObject);
				// random add meat num
				if(Random.Range(1,11) > 5){
					Meat._instance.plusMeat(1);
				}
			}
		}


	}

	public void rotate(){
		if (Mathf.Abs(rotateAngle) >= 0.02f){
			float temp = rotateAngle * 0.05f;
			transform.Rotate (new Vector3 (0, temp, 0));
			rotateAngle -= temp;
		}
	}

	public void walkAnimation(){
		anim.SetFloat("run", 0.0F);
		anim.SetFloat("idle", 0F);
		anim.SetFloat("walk", 1.0F);
	}
	public void idleAnimation(){
		anim.SetFloat("idle", 1F);
		anim.SetFloat("walk", 0.0F);
		anim.SetFloat("run", 0F);
	}
		
	public void die(){
		anim.SetFloat("death", 1.0F);
		anim.SetFloat ("walk", 0.0F);
		//GameObject.Destroy (this.gameObject);
		TrollSpawn.trollNum--;
		startDestroy = true;
	}
}
