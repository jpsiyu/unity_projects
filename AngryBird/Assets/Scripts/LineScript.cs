using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {

	public LineRenderer line;
	public Transform player;
	public CircleCollider2D circle;
	public bool isFront;

	private bool showLine;	
	private Transform thisTransform;
	private Ray ray;


	// Use this for initialization
	void Start () {
		thisTransform = GetComponent<Transform> ();
		ray = new Ray (thisTransform.position, Vector3.zero);
		LineSetup ();
	}

	void LineSetup(){
		showLine = true;
		Vector3 newPos = ResetLinePoint( thisTransform.position);


		line.SetPosition (0, newPos);
		
		//line.SetPosition (0, thisTransform.position);
		line.sortingLayerName = "Foreground";
	}

	void LineUpdate(){
		// now we count a direction
		Vector3 direction = (player.position - this.transform.position);

		// we use a ray to get this;
		ray.direction = player.position - this.transform.position;
		Vector3 target;
		if(isFront)
			target = ray.GetPoint (direction.magnitude + circle.radius);
		else
			target = ray.GetPoint (direction.magnitude - circle.radius);
		line.SetPosition (1, ResetLinePoint(target));
	}
	
	// Update is called once per frame
	void Update () {
		if(showLine)
			LineUpdate ();
	}

	Vector3 ResetLinePoint(Vector3 old){
		old.Set (old.x, old.y, -1f);
		return old;
	}
}
