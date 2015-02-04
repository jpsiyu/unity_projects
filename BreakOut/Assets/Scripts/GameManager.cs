using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public int lives;
	public int bricks;
	public float resetDelay;
	
	public Text livesText;
	
	public GameObject gameOver;
	public GameObject youWin;
	public GameObject loseLive;
	public GameObject paddlePrefab;
	

	private GameObject clonePaddle;
	
	public  static GameManager instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy(gameObject);
		}
		
		Setup ();
	}
	
	void Setup(){
		clonePaddle = Instantiate (paddlePrefab, paddlePrefab.transform.position, Quaternion.identity) as GameObject;
	}
	
	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWin.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
		if (lives < 1)
		{
			loseLive.SetActive(false);
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		loseLive.SetActive (true);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		loseLive.SetActive (false);
		clonePaddle = Instantiate(paddlePrefab, paddlePrefab.transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		audio.Play ();
		CheckGameOver();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}