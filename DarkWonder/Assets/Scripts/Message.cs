using UnityEngine;
using UnityEngine.UI;	
using System.Collections;

public class Message : MonoBehaviour {

	public static Message _instance;
	public Text text;

	private bool startTimer = false;
	private float timer;
	// Use this for initialization
	void Start () {
		_instance = this;
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (startTimer) {
			timer -= Time.deltaTime;
			if(timer <= 0){
				startTimer = false;
				this.gameObject.SetActive(false);
			}
		}
	}

	public void showMsg(string Msg){
		text.text = Msg;
		this.gameObject.SetActive (true);
	}

	public void hide(){
		this.gameObject.SetActive (false);
	}

	public void showMsg(string msg, float time){
		showMsg (msg);
		startTimer = true;
		timer = time;
	}
}
