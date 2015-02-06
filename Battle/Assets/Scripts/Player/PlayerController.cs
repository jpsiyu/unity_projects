using UnityEngine;
using System.Collections;

public enum PlayerPositionInZ{
	Top, Middle, Bottom
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public int maxPlayerHealthy;
	public int playerHealthy;
	public PlayerPositionInZ ppz;
	public float recoverTimeLength;
	public bool isDead;

	private Vector3 pos;
	private Animator anim;
	private float z;
	private bool keyFrameAttacking;
	private float recoverTimePoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ppz = PlayerPositionInZ.Middle;
		playerHealthy = maxPlayerHealthy;
		recoverTimePoint = Time.time;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameWin){
			if(!anim.GetBool("Win"))
				anim.SetBool("Win", true);
			return;
		}
		if(anim.GetBool("Die"))
			return;
		ManWalk ();
		ManRoad ();
		ManAttack ();
		Recover ();
	}


	void ManRoad(){

		if(isDead)
			return;

		if(Input.GetKeyDown(KeyCode.W) && ppz==PlayerPositionInZ.Middle)
			ppz = PlayerPositionInZ.Top;

		else if(Input.GetKeyDown(KeyCode.W) && ppz==PlayerPositionInZ.Bottom)
			ppz = PlayerPositionInZ.Middle;
		else if(Input.GetKeyDown(KeyCode.S) && ppz==PlayerPositionInZ.Top)
			ppz = PlayerPositionInZ.Middle;
		else if(Input.GetKeyDown(KeyCode.S) && ppz==PlayerPositionInZ.Middle)
			ppz = PlayerPositionInZ.Bottom;
		
		switch(ppz){
		case PlayerPositionInZ.Top: z = 10f;  break;
		case PlayerPositionInZ.Middle: z = 0f; break;
		case PlayerPositionInZ.Bottom: z = -10f; break;
		default: z = 0; break;
		}
		pos.Set (transform.position.x, transform.position.y, z);
		transform.position = pos;
	}

	void ManWalk(){
	
		// move when not attacking
		float h = Input.GetAxis ("Horizontal");
		if(!anim.GetBool("Attack") && Mathf.Abs(h) > 0.1f && !anim.GetBool("Die")){
			anim.SetBool("Walk", true);

			pos.Set(h * speed * Time.deltaTime + transform.position.x, 
			        transform.position.y, z);
			transform.position = pos;

					
		}else{
			anim.SetBool("Walk", false);
		}

		if(playerHealthy <= 0)
			ManDie();
	}

	// player have a recover system when not attacking
	void Recover(){
		if(playerHealthy == maxPlayerHealthy || anim.GetBool("Attack"))
			return;
		if (Time.time >= recoverTimePoint + recoverTimeLength) {
			playerHealthy ++;
			recoverTimePoint = Time.time;
		}
	}

	void ManAttack(){
		if (Input.GetKeyDown (KeyCode.J) && !anim.GetBool("Attack")) {
			anim.SetBool("Walk", false);
			anim.SetBool("Attack", true);
			// return idle after 2s
			Invoke("AttackToIdle", 2f);
		}
	}

	public void PlayerAttackedByEnemy(int s){
		anim.SetTrigger("Attacked");
		playerHealthy -= s;
		// when attacked, the recover system will be delayed
		recoverTimePoint = Time.time;
	}

	void AttackToIdle(){
		anim.SetBool ("Attack", false);
	}

	public bool IsAttacking(){
		return keyFrameAttacking;
	}

	public void ManDie(){
		anim.SetBool ("Die", true);
		isDead = true;
	}

	public void rebirth(){
		anim.SetBool ("Die", false);
		isDead = false;
	}

	public void OnKeyFrameEvent(){
		keyFrameAttacking = true;
	}
	public void OnKeyFrameEventEnd(){
		keyFrameAttacking = false;
	}
}
