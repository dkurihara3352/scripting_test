using UnityEngine;
using System.Collections;

public static class ExtentionMethods {

	public static void ResetTransformation(this Transform trans){

		trans.position = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = new Vector3(1,1,1);
	}

	public static int mySigma(this int start, int end){
		int result = 0;
		for(int i = start; i <= end; i++){
			//Debug.Log("for loop interated " + i + " times");
			result += start + i - 1;
			//Debug.Log("now result is of value: " + result);
		}
		return result;
	}
}
