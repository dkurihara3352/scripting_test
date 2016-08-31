using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InventoryItemList))]
[CanEditMultipleObjects]

public class InventoryItemListCustomInspector : Editor {

	SerializedProperty itemListProp;

	void OnEnable(){
		itemListProp = serializedObject.FindProperty("itemList"); 
	}

	public override void OnInspectorGUI(){
		serializedObject.Update();
		EditorGUILayout.PropertyField(itemListProp,true);
		serializedObject.ApplyModifiedProperties();
	}
}
