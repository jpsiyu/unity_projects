using UnityEngine;
using System.Collections;

public class Training : MonoBehaviour {

	public float trainTime = 3.0f;
	public bool isTimerRun = false;
	private float timer;

	public bool trainSuccess = false;
	public GameObject skill;
	public GameObject trainText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0 && isTimerRun == true) {
			Message._instance.showMsg("remain "+timer.ToString("0.0")+" seconds");
			timer -= Time.deltaTime;
			if(timer <= 0){
				trainSuccess = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canUseSkill=true;
				skill.SetActive(true);
				Message._instance.showMsg ("learned skill");
			}
		}
	}

	void OnTriggerEnter(Collider other){
		//print(" enter");
		if (other.gameObject.tag == "Player" && trainSuccess==false) {
			timer = trainTime;
			isTimerRun = true;
			//trainText.SetActive(true);
			Message._instance.showMsg("remain"+timer+" seconds");
		}
	}

	void OnTriggerExit(Collider other){
		//print(" exit");
		if (other.gameObject.tag == "Player") 
		{
			timer = 0.0f;
			isTimerRun = false;
			//trainText.SetActive(false);
			print (trainSuccess);
			Message._instance.hide();
		}
	}

	void OnTriggerStay(Collider other){
		//print(" stay");
	}
}
