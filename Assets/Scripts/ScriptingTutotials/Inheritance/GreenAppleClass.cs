using UnityEngine;
using System.Collections;

public class GreenAppleClass : AppleClass {

	public GreenAppleClass(){
		color = "Green";
		Debug.Log("1st GreenAppleClass constructor is called.");

	}

	public GreenAppleClass(string colorParam): base(colorParam){
		color = colorParam;
		Debug.Log("2nd GreenAppleClass constructor is called.");
	}
}
