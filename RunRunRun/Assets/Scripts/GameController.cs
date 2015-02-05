using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int score;

	public static bool getPower;
	public float powerDisapearTime;
	public float powerTimer;

	public GUIStyle style;

	// Use this for initialization
	void Start () {
		score = 0;
		powerTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		score += 1;

	}

	void OnDisable(){
		PlayerPrefs.SetInt ("Score", score);
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 800, 30), "Score: " + score, style);


		if(getPower){
			GUI.Label (new Rect (200, 10, 50, 30), "+1000", style);
			powerTimer += Time.deltaTime;
		}
		if (powerTimer > powerDisapearTime) {
			powerTimer = 0.0f;
			getPower = false;
		}
	}

	public static void AddPowerScore(int powerScore){
		score += powerScore;
	}

}
