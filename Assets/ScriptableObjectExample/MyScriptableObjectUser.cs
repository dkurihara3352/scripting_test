using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyScriptableObjectUser : MonoBehaviour {

	public	MyScriptableObjectClass myScrObj;
	List<Light> myLights;
	bool isToggleOn = false;
	// Use this for initialization
	void Start () {
		myLights = new List<Light>();
		foreach(Vector3 spawnPoint in myScrObj.spawnPoints){
			GameObject obj = new GameObject("Light");
			obj.AddComponent<Light>();
			Light thisLight = obj.GetComponent<Light>();
			thisLight.enabled = false;
			obj.transform.position = spawnPoint;
			myLights.Add(thisLight);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
			ToggleLights();
		}
	}

	void ToggleLights(){

		isToggleOn = !isToggleOn;

		if(isToggleOn){
			for(int i = 0; i < myLights.Count; i ++){
				myLights[i].enabled = true;
				Debug.Log("light turned");
				if(myScrObj.isColorRandom){
					myLights[i].color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
				}else myLights[i].color = myScrObj.thisColor;
			}
			Debug.Log("On");
		}else{
			for(int i = 0; i < myLights.Count; i ++){
				myLights[i].enabled = false;
			}
			Debug.Log("Off");
		}

	}
}
