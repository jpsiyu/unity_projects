using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing;

	Vector3 offSet;

	void Start(){
		offSet = transform.position - target.position + new Vector3(0f,0f,5f);
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offSet;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing*Time.deltaTime);

	}
}
