using UnityEngine;
using System.Collections;
using System;//this namespace is required

public class LambdaExpression : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Func<int,int> multBySelf = x => x*x;
		Debug.Log(multBySelf(10));
		int factor = 10;
		int input = 30;
		Action<int> multByFactor = (int x) =>{ x = x * factor;};
		multByFactor(input);
		Debug.Log(input);
		//the last arg is the output
		Func<int, float, float, float> mult3nums = (int x, float y, float z) =>{return x*y*z; };
		Debug.Log(mult3nums(10, 1.5f, 2.5f));


		//this seems not valid, action with no input args...

//		Action<> incrementFactor = ()=> {factor++;};
//		incrementFactor();
//		Debug.Log(factor);
//		incrementFactor();
//		Debug.Log(factor);
//		incrementFactor();
//		Debug.Log(factor);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
