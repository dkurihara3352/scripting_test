using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomPropertyDrawer(typeof(ScaledCurve))]
public class ScaledCurvePropertyDrawer : PropertyDrawer {

	const int curveWidth = 50;
	const float min = 0f;
	const float max = 1f;

	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label){
		SerializedProperty scale = prop.FindPropertyRelative("scale");
		SerializedProperty curve = prop.FindPropertyRelative("curve");

		//Draw scale
		EditorGUI.Slider( new Rect(pos.x, pos.y, pos.width - curveWidth, pos.height), scale, min, max, label);

		//Draw curve
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		EditorGUI.PropertyField(new Rect(pos.width - curveWidth, pos.y, curveWidth, pos.height), curve, GUIContent.none);
		EditorGUI.indentLevel = indent;
	}
}
