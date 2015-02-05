using UnityEngine;
using System.Collections;

public class SkillCD : MonoBehaviour {

	private UISprite sprite;
	public float CDTime;
	public bool canRelease;

	private float currentTimePass;


	// Use this for initialization
	void Start () {
		sprite = GetComponent<UISprite> ();
		canRelease = true;
		currentTimePass = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && canRelease) {
			Debug.Log ("Release skill");
			canRelease = false;
		}
		if (!canRelease) {
			currentTimePass += Time.deltaTime;
			sprite.fillAmount = (currentTimePass/CDTime);
//			Debug.Log (currentTimePass/CDTime);
			
		}
		if (currentTimePass >= CDTime) {
			canRelease = true;
			sprite.fillAmount = 0;
			currentTimePass = 0;
		}
	}
}
