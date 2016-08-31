using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (GameControl))]
public class GameControlEditor : Editor {

	public override void OnInspectorGUI ()
	{
		GameControl myTarget = (GameControl)target;
		myTarget.areaRect = EditorGUILayout.RectField("area rectangle", myTarget.areaRect);
		myTarget.health = EditorGUILayout.IntField("Health", myTarget.health);
		myTarget.level = EditorGUILayout.IntField("Level", myTarget.level);
	}
}
