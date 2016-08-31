using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BuildObject))]
public class BuildObjectEditor : Editor {

	public override void OnInspectorGUI(){

		BuildObject myTarget = (BuildObject)target;
		DrawDefaultInspector();

		if(GUILayout.Button("Build Object")){

			myTarget.InstantiateObject();
		}


	}
}
