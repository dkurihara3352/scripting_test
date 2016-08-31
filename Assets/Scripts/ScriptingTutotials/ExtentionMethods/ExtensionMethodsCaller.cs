using UnityEngine;
using System.Collections;

public class ExtensionMethodsCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int res = 10.mySigma(20);
		Debug.Log(res);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
