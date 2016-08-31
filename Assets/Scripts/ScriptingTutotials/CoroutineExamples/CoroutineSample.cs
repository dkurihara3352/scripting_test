using UnityEngine;
using System.Collections;

public class CoroutineSample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(MyCoroutine(5f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float targetTime;
	IEnumerator MyCoroutine(float timeParam){
		targetTime = timeParam;
		float elapsedTime = 0.0f;
		Debug.Log("MyCoroutine has started at " + Time.time);
		while(targetTime >= elapsedTime){
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Debug.Log("reached the target at " + Time.time);
		yield return new WaitForSeconds(3f);
		Debug.Log("MyCoroutine has finished at " + Time.time);
	}
}
