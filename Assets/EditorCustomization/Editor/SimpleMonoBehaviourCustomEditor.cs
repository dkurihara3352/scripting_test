using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SimpleMonoBehaviour))]
public class SimpleMonoBehaviourCustomEditor :Editor {

	#region Using SerializedObject (hard but surer way)
	//Under this method, undo is auto-implemented, so is multiple object editing
	SerializedProperty myIntProp;

	void OnEnable ()
	{
		myIntProp = serializedObject.FindProperty ("myInt");
	}

	public override void OnInspectorGUI ()
	{

		serializedObject.Update ();
		EditorGUILayout.IntSlider (myIntProp, 0, 100);
		myIntProp.intValue = EditorGUILayout.IntField (myIntProp.intValue);
		serializedObject.ApplyModifiedProperties ();
		
	}

	#endregion

	#region implementing Undo by myself

	//when not using SerializedObject, you need to implement you own Undo
	//system and multiple object editing.
	//Easy to access component via target, but very tedious and hard to implenent 
	//these features.

//	SimpleMonoBehaviour myTarget;
//
//	void OnEnable ()
//	{
//		myTarget = (SimpleMonoBehaviour)target;
//	}
//
//	public override void OnInspectorGUI ()
//	{
//		EditorGUI.BeginChangeCheck ();
//		int newInt = EditorGUILayout.IntField (myTarget.myInt);
//		if (EditorGUI.EndChangeCheck ()) {
//			Undo.RecordObject (myTarget, "Change myInt");
//			myTarget.myInt = newInt;
//		}
//	}

	#endregion
}
