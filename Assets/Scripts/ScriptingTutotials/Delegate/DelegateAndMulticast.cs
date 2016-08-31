using UnityEngine;
using System.Collections;

public class DelegateAndMulticast : MonoBehaviour {

	delegate void MyDelegate(int numParam);
	MyDelegate myDel;
	delegate void MyMultiCastDelegate();
	MyMultiCastDelegate myDelMult;
	// Use this for initialization
	void Start () {
		myDel = PrintNum;
		myDel(10);
		myDel = DoubleNum;
		myDel(10);

		myDelMult += PrintHello;
		myDelMult += PrintWorld;

		myDelMult();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PrintNum(int intParam)
	{
		Debug.Log(intParam + " is simply returned.");
	}

	void DoubleNum(int intParam)
	{
		Debug.Log(intParam + " is doubled and returned to be " + intParam*2);
	}

	void PrintHello(){
		Debug.Log("Hello, ");
	}

	void PrintWorld(){
		Debug.Log("World!");
	}

}
