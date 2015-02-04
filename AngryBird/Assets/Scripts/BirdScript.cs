using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {


	private int hitPoint;
	private SpriteRenderer SRenderer;
	private BoxCollider2D box;
	private ParticleSystem parti;
	private Rigidbody2D rigi;
	private AudioSource audio;

	public float hitSpeed;

	// Use this for initialization
	void Start () {
		hitPoint = 1;
		SRenderer = GetComponent<SpriteRenderer> ();
		parti = GetComponent<ParticleSystem> ();
		box = GetComponent<BoxCollider2D> ();
		rigi = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.collider.tag != "Damage")
			return;

		if(other.relativeVelocity.sqrMagnitude < hitSpeed*hitSpeed)
			return;

		hitPoint--;
		if(hitPoint <= 0)
			Kill();
	}
	void Kill(){
		SRenderer.enabled = false;
		box.enabled = false;
		rigi.isKinematic = true;
		audio.Play ();
		parti.Play ();
	}
}
