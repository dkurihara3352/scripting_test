using UnityEngine;
using System.Collections;

public class AdditionScrCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AdditionScr addScr = new AdditionScr();
		int numA = 10;
		int numB = 20;
		int addedNum = addScr.Add(numA, numB);
		Debug.Log(numA + " + " + numB + " equals " + addedNum);
		string strA = "Hello ";
		string strB = "World!";
		string addedStr = addScr.Add(strA, strB);
		Debug.Log(strA + " + " + strB + " equals " + addedStr);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
