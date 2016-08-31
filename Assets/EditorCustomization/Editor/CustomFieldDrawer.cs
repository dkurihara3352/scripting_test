using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(CustomFieldAttribute))]
public class CustomFieldDrawer : PropertyDrawer {

	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label){

		CustomFieldAttribute cusAtt = (CustomFieldAttribute)attribute;

		EditorGUI.MinMaxSlider(label, pos, ref cusAtt.min, ref cusAtt.max, cusAtt.minLimit, cusAtt.maxLimit);

		GUIContent[] labels = new GUIContent[4]{new GUIContent("min"), new GUIContent("max")
			, new GUIContent("min limit"), new GUIContent("max limit")};
		float[] values = new float[4]{cusAtt.min, cusAtt.max, cusAtt.minLimit, cusAtt.maxLimit};
		Rect rect = new Rect(pos){y = pos.y + EditorGUIUtility.singleLineHeight, height = EditorGUIUtility.singleLineHeight};
		EditorGUI.MultiFloatField(rect, labels, values);

	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label)*3;
	}
}
