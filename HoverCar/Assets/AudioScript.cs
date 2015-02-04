using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioSource source;
	public float volumeSetting;
	public float volumeMin;
	public float volumeMax;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		volumeSetting = Input.GetAxis ("Vertical");
		source.volume = Mathf.Clamp (volumeSetting, volumeMin, volumeMax);
	}
}
