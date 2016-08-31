using UnityEngine;
using System.Collections;

public class TurnMaterialColor : MonoBehaviour {

	Renderer rd;

	void Awake(){
		rd = GetComponent<Renderer>();
	}

	void OnEnable(){
		Broadcaster.OnClicked += SetRandomColorToMaterial;
	}

	void OnDisable(){
		Broadcaster.OnClicked -= SetRandomColorToMaterial;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetRandomColorToMaterial(){
		rd.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}
}
