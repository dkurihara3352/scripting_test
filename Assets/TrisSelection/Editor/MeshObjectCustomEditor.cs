using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

//This script governs the look and behaviour of MeshData ScriptableObject in inspector
//Converted MeshData consequently needs to be set with Zones
//Once zones are created the MeshData is assinged to MeshConverter for further tris assignment
//Active zone is switched in this object's inspector, not one of the converter

[CustomEditor(typeof(MeshDataObject))]
public class MeshObjectCustomEditor : Editor {

//	string meshDataName;
//	bool showTris = false;
//	int zonesToCreate;
//	GUIStyle headerStyle;
//	MeshDataObject myTarget;


	//move to scriptableobject
	//these need to be saved and not lost when reloading app

//	string[] toolBarStrings;
//	MeshZone activeZone;
//	int activeZoneIndex;


	void OnEnable(){

//		myTarget = (MeshDataObject)serializedObject.targetObject;
//		headerStyle = new GUIStyle();
//		headerStyle.fontStyle = FontStyle.Bold;
	}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();
//		SerializedProperty zoneGroupProp = serializedObject.FindProperty("zoneGroup");
//		EditorGUILayout.PropertyField(zoneGroupProp, true);
//		SerializedProperty nameProp = serializedObject.FindProperty("objectName");

//		serializedObject.Update();
//		EditorGUI.BeginChangeCheck();{
//
////			EditorGUILayout.PropertyField(nameProp, new GUIContent("Object Name"), false);
////			MeshDataObject myTarget = (MeshDataObject)serializedObject.targetObject;
//
//			myTarget.objectName = EditorGUILayout.TextField("Mesh Data Name", myTarget.objectName);
//			Undo.RecordObject(serializedObject.targetObject, "myInspector");
//
////			myTarget.isReady = EditorGUILayout.Toggle("ready for scene editing", myTarget.isReady);
//
//			//CoupledTris
//			EditorGUILayout.PropertyField(serializedObject.FindProperty("coupledTris"),true);
//			#region Coupled Tris
////			if (myTarget.coupledTris.Length != 0) {
////				
////				showTris = EditorGUILayout.Foldout (showTris, "Coupled Tris: " + myTarget.coupledTris.Length.ToString ());
////				if (showTris) {
////					EditorGUILayout.BeginVertical ();
////					{
////						for (int i = 0; i < myTarget.coupledTris.Length; i++) {
////							EditorGUILayout.BeginVertical ();
////							{
////								EditorGUILayout.LabelField (myTarget.coupledTris [i].triName);
////								EditorGUI.indentLevel++;
////								EditorGUILayout.BeginVertical ();
////								{
////									EditorGUILayout.BeginHorizontal ();
////									{
////										
////										EditorGUILayout.LabelField ("p0", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("p1", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("p2", GUILayout.MaxWidth (40));
////										
////										EditorGUILayout.LabelField ("N", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("T", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("B", GUILayout.MaxWidth (40));
////										
////										EditorGUILayout.LabelField ("C", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("U", GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField ("V", GUILayout.MaxWidth (40));
////										
////										
////									}
////									EditorGUILayout.EndHorizontal ();
////
////									EditorGUILayout.BeginHorizontal ();
////									{
////
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].p0.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].p1.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].p2.ToString (), GUILayout.MaxWidth (40));
////
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].normal.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].tangent.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].binormal.ToString (), GUILayout.MaxWidth (40));
////
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].centroid.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].uDir.ToString (), GUILayout.MaxWidth (40));
////										EditorGUILayout.LabelField (myTarget.coupledTris [i].vDir.ToString (), GUILayout.MaxWidth (40));
////
////									}
////									EditorGUILayout.EndHorizontal ();
////									
////								}
////								EditorGUILayout.EndVertical ();
////
////								EditorGUI.indentLevel--;
////							}
////							EditorGUILayout.EndVertical ();
////						}
////						
////					}
////					EditorGUILayout.EndVertical ();
////				}
////			} else
////				EditorGUILayout.HelpBox ("Coupled Tris are not assinged", MessageType.Error);
//			#endregion
//
//			//Zones
//			#region Zones
////			EditorGUILayout.Space ();
////			EditorGUILayout.LabelField ("Mesh Zones", headerStyle);
////
////			zonesToCreate = EditorGUILayout.IntField ("number of zones to create: ", zonesToCreate);
////			Undo.RecordObject (serializedObject.targetObject, "myInspector");
////
////			if (zonesToCreate != 0) {
////				if (GUILayout.Button ("Create Zones", GUILayout.MaxWidth (200))) {
////					CreateZones (zonesToCreate);	
////				}
////			}
////
////			if (myTarget.meshZones != null && myTarget.meshZones.Count != 0) {
////				for (int i = 0; i < myTarget.meshZones.Count; i++) {
////					EditorGUILayout.BeginVertical ();
////					{
////
////						EditorGUILayout.BeginHorizontal ();
////						{
////							myTarget.meshZones [i].showZone = EditorGUILayout.Foldout (myTarget.meshZones [i].showZone,
////								myTarget.meshZones [i].zoneName);
////							myTarget.meshZones [i].zoneColor = EditorGUILayout.ColorField (myTarget.meshZones [i].zoneColor);
////							Undo.RecordObject (serializedObject.targetObject, "myInpector");
////							EditorGUILayout.LabelField ("Zone Tris Count: " + myTarget.meshZones [i].zoneTris.Count.ToString ());
////
////						}
////						EditorGUILayout.EndHorizontal ();
////
////					
////						if (myTarget.meshZones [i].showZone) {
////
////							if (myTarget.meshZones [i].zoneTris.Count != 0) {
////
////								for (int j = 0; j < myTarget.meshZones [i].zoneTris.Count; j++) {
////									EditorGUILayout.LabelField (myTarget.meshZones [i].zoneTris [j].triName);
////								}
////
////							} else
////								EditorGUILayout.HelpBox ("There's no zone tris assigned yet", MessageType.Error);
////
////						}
////
////					}
////					EditorGUILayout.EndVertical ();
////
////				}
////			} else
////				EditorGUILayout.HelpBox ("There's no zones created", MessageType.Error);
//			#endregion
//
//			//Active Zone
//			#region Active Zone
////			EditorGUILayout.Space ();
////			EditorGUILayout.LabelField ("Active Zone", headerStyle);
////
////			if (myTarget.toolBarStrings != null)
////				SetActiveZone (GUILayout.Toolbar (myTarget.activeZoneIndex, myTarget.toolBarStrings));
////
////
////			if (myTarget.activeZone != null) {
////
////				EditorGUILayout.BeginVertical ();
////				{
////
////					EditorGUILayout.BeginHorizontal ();
////					{
////
////						EditorGUILayout.LabelField (myTarget.activeZone.zoneName.ToString (), GUILayout.MaxWidth (100));
////						EditorGUILayout.ColorField (myTarget.activeZone.zoneColor, GUILayout.MinWidth (100));
////						EditorGUILayout.LabelField ("active zone tris count: " + myTarget.activeZone.zoneTris.Count.ToString ());
////
////					}
////					EditorGUILayout.EndHorizontal ();
////					for (int i = 0; i < myTarget.activeZone.zoneTris.Count; i++) {
////						EditorGUILayout.LabelField (myTarget.activeZone.zoneTris [i].triName.ToString ());
////					}
////
////				}
////				EditorGUILayout.EndVertical ();
////
////			} else
////				EditorGUILayout.HelpBox ("Active Zone is not set", MessageType.Error);
//			#endregion
//
//
//		}if(EditorGUI.EndChangeCheck()){
//			serializedObject.ApplyModifiedProperties();
//			EditorUtility.SetDirty(serializedObject.targetObject);
//		}
	}



//	void CreateZones(int num){
//		myTarget.meshZones = new List<MeshZone>();
//		MeshZone.zonesSize = 0;
//		myTarget.toolBarStrings = new string[zonesToCreate];
//		for(int i = 0; i < zonesToCreate; i++){
//			MeshZone newMeshZone = new MeshZone();
//			myTarget.meshZones.Add(newMeshZone);
//			myTarget.toolBarStrings[i] = i.ToString();
//		}
//	}

//	public void SetActiveZone(int index){
//		if(myTarget.meshZones.Count != 0 && myTarget.activeZoneIndex!= -1){
//			myTarget.activeZone = myTarget.meshZones[index];
//			myTarget.activeZoneIndex = index;
//		}else return;
//	}


}
