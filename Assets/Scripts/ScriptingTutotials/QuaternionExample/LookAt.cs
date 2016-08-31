using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Transform target;
	public float smoothingK = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		SimpleLookAt(target);
		SmoothLookAt(target);
	}

	void SimpleLookAt(Transform tarParm){
		Vector3 relativePos = tarParm.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePos);
	}

	void SmoothLookAt(Transform tarParam){
		Vector3 relativePos = tarParam.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(relativePos);
		Quaternion curRotation = transform.rotation;
		transform.rotation = Quaternion.Slerp(curRotation, targetRotation, Time.deltaTime * smoothingK);
	}
}
