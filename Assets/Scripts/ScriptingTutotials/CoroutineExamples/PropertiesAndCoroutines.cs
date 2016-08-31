using UnityEngine;
using System.Collections;

public class PropertiesAndCoroutines : MonoBehaviour {

	public float smoothing = 7f;

	private Vector3 target;

	public Vector3 Target{

		get{return target;}
		set{
			target = value;
			StopCoroutine("Movement");
			StartCoroutine("Movement", target);
		}
	}

	IEnumerator Movement(Vector3 targetParam){

		while(Vector3.Distance(transform.position, targetParam)> .05f)
		{
			transform.position = Vector3.Slerp(transform.position, target, smoothing * Time.deltaTime);

			yield return null;
		}
	}

	void Update(){}
}
