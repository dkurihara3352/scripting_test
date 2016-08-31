using UnityEngine;
using System.Collections;

public class FruitClass{

	protected string color;

	public FruitClass(){

		color = "Orange";
		Debug.Log("1st FruitClass constructor is called.");

	}
	public FruitClass(string colorParam){

		color = colorParam;
		Debug.Log("2nd FruitClass constructor is called.");
	}

	
	public void Chop(){
		Debug.Log("The " + color + " fruit has been chopped.");
	}

	public void SayHello(){
		Debug.Log("Hello, I am a fruit.");
	}
}
