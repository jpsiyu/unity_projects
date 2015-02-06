﻿using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	public int goldValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GoldController.AddGold(goldValue);
			Destroy(this.gameObject);
		}
	}
}
