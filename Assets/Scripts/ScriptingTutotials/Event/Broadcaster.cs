using UnityEngine;
using System.Collections;

public class Broadcaster: MonoBehaviour {

	public delegate void ClickAction();
	public static event ClickAction OnClicked;

	void OnGUI(){

		if(GUI.Button(new Rect(Screen.width/2 - 50, 50, 100, 30), "Click")){
			if(OnClicked != null){
				OnClicked();
			}else{
				Debug.Log("There's no subscriber currently");
			}
		}
	}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
