using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (LevelScript))]
public class LevelScriptEditor : Editor{


	public override void OnInspectorGUI ()
	{
		LevelScript myLevelScript = (LevelScript)target;
		myLevelScript.experience = EditorGUILayout.IntField("Experience", myLevelScript.experience);
		EditorGUI.indentLevel++;
		EditorGUILayout.LabelField("Level", myLevelScript.Level.ToString());
		//Color modification
		Renderer rend = myLevelScript.transform.GetComponent<Renderer>();
		Color col = rend.sharedMaterial.color;
		rend.sharedMaterial.color = EditorGUILayout.ColorField("Material Color", col);

	}
}
