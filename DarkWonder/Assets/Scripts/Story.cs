using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Story : MonoBehaviour {

	private RawImage image;
	
	public Texture[] textures;

	private int index = 0;
	// Use this for initialization
	void Start () {
		image = this.GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			index++;
			if(index >= 4){
				Application.LoadLevel("game");
			}else{

				image.texture = textures[index];
			}

		}
	}

	public void OnGUI(){
		if(index == 0){
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2, 200, 50), "Er, Er, En...");
		}else if(index ==1){
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2, 200, 50), "En, En, Er....");
		}else if(index == 2){
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2, 200, 50), "Oh, fuck..., fuck...");
		}else if(index == 3){
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2, 200, 50), "Er-Er-Er........");
		}else if(index == 4){
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2, 200, 50), "Er-On-Oh...Er-En-Oh...");
		}
	}
	
}
