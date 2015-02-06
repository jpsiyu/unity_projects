using UnityEngine;
using System.Collections;

public class FingerTouch : MonoBehaviour {

	private LineRenderer line;
	private int lineVertexCount;
	private Vector3 t;
	private Vector3 p;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		lineVertexCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.touchCount>0){
//			Touch touch = Input.GetTouch(0);
//			if(touch.phase == TouchPhase.Moved){
//				line.SetVertexCount(lineVertexCount+1);
//				t.Set(Input.mousePosition.x, Input.mousePosition.y, 15f);
//				line.SetPosition(lineVertexCount,
//				                 Camera.main.ScreenToWorldPoint(t));				                    
//				lineVertexCount++;
//			}
//		}
		if(Input.GetMouseButton(0)){

//			print(Input.mousePosition + " "  + Camera.main.ScreenToWorldPoint( Input.mousePosition));

			line.SetVertexCount(lineVertexCount+1);
			t.Set(Input.mousePosition.x, Input.mousePosition.y, 10f);
			print (Camera.main.ScreenToViewportPoint( t));
//			t = Input.mousePosition;
			line.SetPosition(lineVertexCount,
			                 Camera.main.ScreenToWorldPoint(t));				                    
			lineVertexCount++;

			// add box collider for this line
			AddBoxCollider(line);

//			BoxCollider bc = gameObject.AddComponent<BoxCollider>();
//			bc.transform.position = line.transform.position;
////			bc.transform.position = Camera.main.ScreenToWorldPoint(t);
//			p.Set(0.1f, 0.1f, 0.1f);
//			bc.size = p;
//			bc.isTrigger  = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			lineVertexCount = 0;
			line.SetVertexCount(0);	

			// destroy colliders
			BoxCollider[] bcs = gameObject.GetComponents<BoxCollider>();
			foreach(BoxCollider b in bcs){
				Destroy(b);
			}
		}
	}

	void AddBoxCollider(LineRenderer l){

		BoxCollider bc = gameObject.AddComponent<BoxCollider>();
		bc.transform.position = l.transform.position;
		p.Set(0.1f, 0.1f, 0.1f);
		bc.size = p;
		bc.isTrigger  = true;
	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}

}
