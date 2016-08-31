using UnityEngine;
using System.Collections;

public class TurnLightColor : MonoBehaviour {

	Light lt;

	void Awake(){
		lt = GetComponent<Light>();	
	}

	void OnEnable(){
		Broadcaster.OnClicked += SetRandomColor;
	}

	void OnDisable(){
		Broadcaster.OnClicked -= SetRandomColor;
	}

	void SetRandomColor(){
		lt.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
