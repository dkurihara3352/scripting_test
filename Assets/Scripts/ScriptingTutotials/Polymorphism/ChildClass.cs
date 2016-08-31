using UnityEngine;
using System.Collections;

public class ChildClass : ParentClass {

	public ChildClass(){
		name = "Child";
		Debug.Log("ChildClass constructor is called.");
	}

	public void CallParent(){
		Debug.Log("Where's Mom?");

	}

	public override void ParentMethod(){
		base.ParentMethod();
		Debug.Log("parent method of child class is called.");
	}

//	public override void ParentMethod(){
//		Debug.Log("Parent method of Child class is called");
//	}
}
