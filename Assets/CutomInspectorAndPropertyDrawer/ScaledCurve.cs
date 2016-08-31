using UnityEngine;
using System.Collections;

[System.Serializable]
public class ScaledCurve{

	public float scale = 1.0f;
	public AnimationCurve curve = AnimationCurve.Linear(0,0,1,1);
}
