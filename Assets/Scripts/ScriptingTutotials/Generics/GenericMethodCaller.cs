using UnityEngine;
using System.Collections;

public class GenericMethodCaller : MonoBehaviour {

	GenericMethodExample genericMethodScr;
	// Use this for initialization
	void Start () {
		genericMethodScr = new GenericMethodExample();
		int myInt = 10;
		int returnedInt = genericMethodScr.GenericMethodStruct<int>(myInt);
		Debug.Log("returned Interger is " + returnedInt);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
