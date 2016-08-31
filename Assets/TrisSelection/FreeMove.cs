using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class FreeMove : MonoBehaviour {

	public Vector3 lookAtPoint = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		transform.LookAt(lookAtPoint);
	}
}
