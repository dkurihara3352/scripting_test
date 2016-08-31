using UnityEngine;
using System.Collections;

public class PolymorphismExample : MonoBehaviour {

	ParentClass parent;
	ChildClass child;

	// Use this for initialization
	void Start () {
		parent = new ParentClass();
		child = new ChildClass();

//		parent = child;//upcasting: putting ChildClass object into a ParentClass container
//		parent.ParentMethod();//variable parent is still a type of ParentClass, so ParentMethod of parent class is called.
//		((ChildClass)parent).ParentMethod();//now var parent is downcasted to the type of ChildClass, child version is called.
//		parent.ParentMethod();
//		child.ParentMethod(); 

		Debug.Log(ReturnName(parent));
		Debug.Log(ReturnName(child));//it's okay to put ChildClass obj into ParentClass container

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string ReturnName(ParentClass parent){
		return parent.name;
	}
}
