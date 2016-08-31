using UnityEngine;
using System.Collections;

public class ParentClass {

	public string name;

	public ParentClass(){
		name = "parent";
		Debug.Log("ParentClass constructor is called.");
	}

	public void PrintName(){
		Debug.Log(name);
	}
	public virtual void ParentMethod(){
		Debug.Log("Parent Method is called.");
	}
}
