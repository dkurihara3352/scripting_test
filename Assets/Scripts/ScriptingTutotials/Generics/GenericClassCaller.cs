using UnityEngine;
using System.Collections;

public class GenericClassCaller : MonoBehaviour {

	GenericClass<string> genericClassString;
	GenericClass<float> genericClassFloat;

	// Use this for initialization
	void Start () {
		genericClassString = new GenericClass<string>();
		genericClassString.UpdateItem("hello");
		Debug.Log(genericClassString.item);

		genericClassFloat = new GenericClass<float>();
		genericClassFloat.UpdateItem(.88f);
		Debug.Log(genericClassFloat.item);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
