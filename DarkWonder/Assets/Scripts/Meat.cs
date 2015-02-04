using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Meat : MonoBehaviour {

	public static Meat _instance;

	public static int meatNum;

	public Text meatCount;

	// Use this for initialization
	void Start () {
		_instance = this;
		this.gameObject.SetActive (false);
		meatNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void plusMeat(int Num) {
		meatNum += Num;
		print (meatNum);
		if (!this.gameObject.activeInHierarchy) {
			this.gameObject.SetActive(true);		
		}
		meatCount.text = meatNum + "";
	}
}
