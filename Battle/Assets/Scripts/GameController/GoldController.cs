using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldController : MonoBehaviour {

	public float goldAddTime;
	public Text goldCounterText;
	public static int goldCounter;

	public static GoldController gc;

	private float currentTime;

	void Awake(){
		if(gc != null)
			Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {


		currentTime = Time.time;
		goldCounter = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameOver || GameController.gameWin)
			return;

		if (Time.time >= currentTime + goldAddTime) {
			goldCounter++;
			currentTime = Time.time;
		}
		goldCounterText.text = "" + goldCounter;
	}

	public static void AddGold(int n){
		goldCounter += n;
	}

	public static void MinGold(int n){
		goldCounter -= n;
	}
}
