using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor {

	public override void OnInspectorGUI(){

		SomeScript myTarget = (SomeScript)target;

		DrawDefaultInspector();
		EditorGUILayout.HelpBox("This is a help box for " + myTarget.ToString(), MessageType.Info);
	}
}
