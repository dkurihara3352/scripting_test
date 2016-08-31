using UnityEngine;
using System.Collections;

public class AccessingPropertiesExample : MonoBehaviour {

	PropertyExample propExScr = new PropertyExample();
	// Use this for initialization
	void Start () {

		Debug.Log("Current Exp: " + propExScr.Experience);
		propExScr.Experience = 38990;
		Debug.Log("Current Exp: " + propExScr.Experience);
		Debug.Log("Current Level: " + propExScr.Level);
		propExScr.Level = 10;
		Debug.Log("Now the exp is " + propExScr.Experience);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
