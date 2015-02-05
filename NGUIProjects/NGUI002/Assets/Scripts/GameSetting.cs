using UnityEngine;
using System.Collections;

public enum Difficuty{
	easy,
	normal,
	hard
}

public enum ControlType{
	touch,
	joystick
}

public class GameSetting : MonoBehaviour {

	public float volumn;
	public Difficuty diff ;
	public ControlType controltype;
	public bool isFullScreen;

	public TweenPosition panelStart;
	public TweenPosition panelOption;

	// Use this for initialization
	void Start () {
		volumn = 1;
		diff = Difficuty.normal;
		controltype = ControlType.touch;
		isFullScreen = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetVolumn(){
//		print ("Volumn " + UISlider.current.value);
	}

	public void SetDiff(){
//		print("Diff " + UIPopupList.current.value);
	}
	public void SetControl(){
//		print ("Control " + UIPopupList.current.value);
	}
	public void SetFullScreen(){
//		print("FunllScreen " + UIToggle.current.value);
	}

	public void ClickButtonStart(){
		print("start");
	}
	public void ClickButtonOption(){
		panelStart.PlayForward ();
		panelOption.PlayForward ();
	}
	public void ClickButtonExit(){
		print("Exit");
	}
	public void ClickButtonFinish(){
		panelStart.PlayReverse ();
		panelOption.PlayReverse ();

	}
}
