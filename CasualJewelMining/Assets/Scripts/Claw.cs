using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {

	public float speed;

	public GameObject miner;
	public GameObject minerGun;
	public LineRenderer line;
	public GameObject superMiner;

	private Vector3 targetPosition;
	private Vector3 startPosition;
	private bool canGoOut = true;
	private GameObject childObject;
	//private LineRenderer line;

	// Use this for initialization
	void Start () {
		//line = GetComponent<LineRenderer> ();
	}

	public bool CanClawGoOut(){
		return canGoOut;
	}

	void OnEnable(){
		canGoOut = true;
		startPosition = transform.position;
		line.SetPosition (0, startPosition);
		//保证下次绘制的时候，1索引对应点在正确的位置
		line.SetPosition (1, startPosition);
	}
	
	// Update is called once per frame
	void Update () {

		if(canGoOut){
			superMiner.GetComponent<SuperMiner>().canMove = false;

			transform.position = Vector3.MoveTowards (transform.position,
		                                         targetPosition,
		                                         speed * Time.deltaTime);
		}else{
			transform.position = Vector3.MoveTowards (transform.position,
			                                          startPosition,
			                                          speed * Time.deltaTime);
		}
		line.SetPosition (1, transform.position);

		if (transform.position == startPosition) {

			if(childObject != null){
				Destroy(childObject);
				GameController.AddScore(10);
			}
		
			gameObject.SetActive(false);
			superMiner.GetComponent<SuperMiner>().canMove = true;
			minerGun.GetComponent<MinerGun>().PrepareRayOut();
			miner.GetComponent<Miner>().StartAnimator();
		}
	}

	public void UpdateTargetPosition(Vector3 tar){
		targetPosition = tar;
	}

	void OnTriggerEnter(Collider other){

		if(other.tag == "EnvBoundary" || other.tag == "Diamond"){
			canGoOut = false;
		}

		if (other.tag == "Diamond") {
			//other.transform.position = transform.position;
			childObject = other.gameObject;
			audio.Play();
			other.transform.SetParent(transform);
		}
	}
}
