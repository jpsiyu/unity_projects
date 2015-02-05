using UnityEngine;
using System.Collections;

public class NGUIButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLabelButtonClick(){
		Debug.Log("label click");
	}

	public void OnSpriteButtonClick(){
		Debug.Log("sprite click");
	}
}
