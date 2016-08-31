using UnityEngine;
using System.Collections;

public class InheritanceClassCaller : MonoBehaviour {

	FruitClass fruit;
	AppleClass apple;
	GreenAppleClass greenApple;
	// Use this for initialization
	void Start () {
		greenApple = new GreenAppleClass("Emerald");
		greenApple.Chop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
