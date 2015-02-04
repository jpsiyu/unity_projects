using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private ArrayList balls;
	private int poolNum = 3;
	private Vector3 spawnPosition;
	private float waitTime = 2.0f;

	public GameObject ball;
	public GameObject bomb;
	public float spawnTime;
	public float boundary;
	public float timeLeft;
	public Text scoreText;
	public Text timeLeftText;
	public Text gameoverText;
	public Button restartButton;

	private static int scores;

	private bool gameOver;

	// Use this for initialization
	void Start () {

		balls = new ArrayList ();

		for (int i = 0; i < poolNum; i++) {
			GameObject o = Instantiate(ball, Vector3.zero, Quaternion.identity) as GameObject;
			o.SetActive(false);
			balls.Add(o);
		}
		GameObject b = Instantiate (bomb, Vector3.zero, Quaternion.identity) as GameObject;
		bomb.SetActive (false);
		balls.Add (b);

		StartCoroutine (Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		if(timeLeft > 0)
			timeLeft -= Time.deltaTime;
		else{
			Invoke("GameOver", 3.0f);
		}
	}

	void FixedUpdate(){

		UpdateText ();


	}

	void UpdateText(){
		timeLeftText.text = "Time Left: " + Mathf.RoundToInt (timeLeft);
		scoreText.text = "Scores: " + scores;
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds(waitTime);
		while(timeLeft > 0){
			GameObject o = balls[Random.Range(0, balls.Count)] as GameObject;
			if(!o.activeInHierarchy){
				spawnPosition.Set(Random.Range(-boundary, boundary), this.transform.position.y, 0.0f);
				o.transform.position = spawnPosition;
				o.SetActive(true);

				yield return new WaitForSeconds(spawnTime);

			}
			//print ("check");
			//yield return new WaitForSeconds(spawnTime);
		}
	} 

	public static void AddScore(int s){
		scores += s;
	}
	public static void MinScore(int s){
		scores -= s;
	}

	void GameOver(){
		gameoverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive (true);
	}

	public static void ResetGame(){
		scores = 0;
	}
}
