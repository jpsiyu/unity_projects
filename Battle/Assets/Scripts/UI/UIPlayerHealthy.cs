using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerHealthy : MonoBehaviour {

	public PlayerController player;
	
	private Vector3 scale;
	private Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		float x = startScale.x * (1.0f * player.playerHealthy / player.maxPlayerHealthy);
		scale.Set ((x > 0)?x:0,
		          startScale.y, startScale.z);
		transform.localScale = scale;
	}
}
