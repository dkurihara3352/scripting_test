using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {

	public PropertiesAndCoroutines propNCrtScr;
	public Camera cam;

	void OnMouseDown()
	{
		Debug.Log("OnMouseDown is called");
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Physics.Raycast(ray, out hit);

		if(hit.collider.gameObject == gameObject)
		{
			Vector3 newTarget = hit.point + new Vector3(0,.5f,0);
			propNCrtScr.Target = newTarget;
		}
	}

	void OnMouseDrag()
	{
		Debug.Log("OnMouseDrag is called");
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Physics.Raycast(ray, out hit);


		if(hit.collider.gameObject == gameObject)
		{
			Vector3 newTarget = hit.point + new Vector3(0,.5f,0);
			propNCrtScr.Target = newTarget;
		}
	}
	void Update(){}
}
