using UnityEngine;
using System.Collections;

public class CustomFieldUsage : MonoBehaviour {

	[SerializeField, CustomFieldAttribute (50f, 75f, 20f, 130f)]
	float myFloat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
