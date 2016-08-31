using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MyPlayer))]
[CanEditMultipleObjects]
public class MyPlayerEditor : Editor {

	SerializedProperty armourProp;
	SerializedProperty damageProp;
	SerializedProperty gunProp;

	void OnEnable(){
		armourProp = serializedObject.FindProperty("armour");
		damageProp = serializedObject.FindProperty("damage");
		gunProp = serializedObject.FindProperty("gun");
	}


	public override void OnInspectorGUI ()
	{
		//base.OnInspectorGUI ();
		serializedObject.Update();

		EditorGUILayout.IntSlider(armourProp, 0, 100, new GUIContent("armour"));
		if(!armourProp.hasMultipleDifferentValues)
			ProgressBar(armourProp.intValue/ 100f/* max value*/, "armour");
		EditorGUILayout.IntSlider(damageProp, 0, 100, new GUIContent("damage"));
		if(!damageProp.hasMultipleDifferentValues)
			ProgressBar(damageProp.intValue/100f, "damage");
		EditorGUILayout.PropertyField(gunProp, new GUIContent("Gun Object"));


		serializedObject.ApplyModifiedProperties();

	}

	void ProgressBar(float value, string label){
		Rect myRect = GUILayoutUtility.GetRect(18, 18, "TextField");
		EditorGUI.ProgressBar(myRect, value, label);
		EditorGUILayout.Space();

	}
}
