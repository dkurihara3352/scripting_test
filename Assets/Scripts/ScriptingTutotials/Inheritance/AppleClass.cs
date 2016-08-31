using UnityEngine;
using System.Collections;

public class AppleClass : FruitClass{

	public AppleClass(){
		color = "Red";
		Debug.Log("1st AppleClass constructor is called.");
	}
	public AppleClass(string colorParam) :base (colorParam){
		color = colorParam;
		Debug.Log("2nd AppleClass constructor is called.");
	}
}
