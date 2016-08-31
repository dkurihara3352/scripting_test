using UnityEngine;
using System.Collections;
using NamespaceExample;

public class NamespaceUsage : MonoBehaviour {

	ClassAInNamespace myClass;
	// Use this for initialization
	void Start () {
		myClass = new ClassAInNamespace();
		myClass.MemberMethodOfClassA("Hey!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
