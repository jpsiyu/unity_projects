using UnityEngine;
using System.Collections;

public enum ArmyType{
	Enemy,
	Allices
}

public class ArmyController : MonoBehaviour {

	public float speed;
	public ArmyType armyType;
	public int armyHealthy;
	public GameObject ad;
	public bool isDead;
	public GameObject gold;
	
	private bool detectedSomething;

	private Vector3 pos;
	private Animator anim;
	public bool keyFrameAttacking;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		detectedSomething = false;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameOver)
			return;

		if (GameController.gameWin) {
			if(armyType == ArmyType.Allices && !anim.GetBool("Win"))
				anim.SetBool("Win", true);
			return;
		}

		if(anim.GetBool("Die"))
			return;

		if(detectedSomething)
			Attack ();
		else
			Walk ();

		if (armyHealthy <= 0) {
			EnemyDie();
		}
			
	}

	public void LoseHealthy(int l){
		anim.SetTrigger ("Attacked");
		armyHealthy -= l;
	}

	void Walk(){
		anim.SetBool ("Attack", false);
		anim.SetBool ("Walk", true);
		pos.Set (speed * Time.deltaTime, 0f, 0f);

		if(armyType == ArmyType.Enemy)
			transform.position -= pos;
		else{
			transform.position += pos;
			
		}
		
	}

	void Attack(){
		anim.SetBool ("Walk", false);
		anim.SetBool ("Attack", true);
		//Invoke ("BackToIdle", 1.5f);
	}

	void BackToIdle(){
		anim.SetBool ("Attack", false);
	}

	public void Detected(){
		detectedSomething = true;
	}
	public void UnDetected(){
		detectedSomething = false;
	}


	// enemy die and disappear
	public void EnemyDie(){
		anim.SetBool ("Walk", false);
		anim.SetBool("Die", true);
		isDead = true;
		if(armyType == ArmyType.Enemy)
			GameController.AddEnemyKilled ();
		// just let army controller trigger undetector method
		//GetComponent<CapsuleCollider> ().transform.localScale = Vector3.zero;
		
		Invoke ("EnemyDestroy", 1.5f);	
	}

	void EnemyDestroy(){
		if(armyType == ArmyType.Enemy && Random.Range(1, 100) > 30){
			pos.Set(transform.position.x + 12f, 0f, transform.position.z);
			Instantiate (gold, pos, Quaternion.identity);
		}
		Destroy (this.gameObject);
	}

	public bool IsAttacking(){
		return keyFrameAttacking;
	}

	void OnKeyFrameEvent(){
		keyFrameAttacking = true;
	}
	void OnKeyFrameEventEnd(){
		keyFrameAttacking = false;
	}
}
