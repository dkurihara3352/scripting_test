using UnityEngine;
using System.Collections;


[System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class CustomFieldAttribute : PropertyAttribute {

	public float min; //preferably readonly too
	public float max; // same here. In this example it's not readolny because these are passed by ref in CustomFieldDrawer
	public readonly float minLimit;
	public readonly float maxLimit;

	public CustomFieldAttribute(float min, float max, float minLimit, float maxLimit){

		this.min = min;
		this.max = max;
		this.minLimit = minLimit;
		this.maxLimit = maxLimit;
	}
}
