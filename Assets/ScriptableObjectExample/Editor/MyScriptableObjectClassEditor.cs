using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MyScriptableObjectClass))]
public class MyScriptableObjectClassEditor : Editor {

	public override void OnInspectorGUI(){

		DrawDefaultInspector();
		//Drawing Array in Custom Inspector
//				serializedObject.Update();
//				MyScriptableObjectClass myTarget = (MyScriptableObjectClass)target;
//				SerializedProperty sps = serializedObject.FindProperty("spawnPoints");
//				EditorGUI.BeginChangeCheck();
//				EditorGUILayout.PropertyField(sps, true);
//				if(EditorGUI.EndChangeCheck())
//					serializedObject.ApplyModifiedProperties();
		
	}
}
