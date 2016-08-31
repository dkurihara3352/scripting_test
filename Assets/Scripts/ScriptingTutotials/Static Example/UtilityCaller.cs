using UnityEngine;
using System.Collections;

public class UtilityCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int a = 200;
		int result = Utility.MultiplyItself(a);
		Debug.Log(a + " multiplied by itself equals = " + result);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
