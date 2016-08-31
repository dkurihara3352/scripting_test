using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//[CustomPropertyDrawer(typeof(MeshDataClass))]
//public class MeshDataClassDrawer : PropertyDrawer {
//
//	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label){
//		SerializedProperty nameProp = prop.FindPropertyRelative("objectName");
//		SerializedProperty transProp = prop.FindPropertyRelative("trans");
//		SerializedProperty meshProp = prop.FindPropertyRelative("mesh");
//		SerializedProperty trisProp = prop.FindPropertyRelative("coupledTris");
//
//		EditorGUI.BeginProperty(pos, label, prop);
//
//		EditorGUI.PropertyField(pos, nameProp, label);
//
//		if(GUILayout.Button("Convert")){
//			
//		}
//
//		EditorGUI.EndProperty();
//
//	}
//}

[CustomEditor(typeof(MeshDataClass))]
[CanEditMultipleObjects]
public class MeshDataClassEditor: Editor{



	void OnEnable(){ 

		//Doing some initial setups for serializedProperty in here seems to cause the odd behaviour...

		//transProp = serializedObject.FindProperty("trans");
//		trisProp = serializedObject.FindProperty("coupledTris");

	

	}

	public override void OnInspectorGUI(){

		SerializedProperty isReadyProp = serializedObject.FindProperty("isReady");
		SerializedProperty transProp = serializedObject.FindProperty("trans");
		SerializedProperty zonesSizeProp = serializedObject.FindProperty("zonesSize");

		MeshDataClass target = (MeshDataClass)serializedObject.targetObject;

		GUIStyle headerStyle = new GUIStyle();
		headerStyle.fontStyle = FontStyle.Bold;

		serializedObject.Update();

		EditorGUI.BeginChangeCheck();{
			
			EditorGUILayout.PropertyField(isReadyProp, false);
			
			//target transform
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Target Transform", headerStyle);
			EditorGUILayout.PropertyField(transProp, false);
			if(target.trans == null){
				EditorGUILayout.HelpBox("target transform not assigned", MessageType.Error);	
			}else if(!target.trans.gameObject.isStatic){
				EditorGUILayout.HelpBox("target transform is not set static", MessageType.Error);
			}else if(target.trans.gameObject.GetComponent<MeshFilter>() == null){
				EditorGUILayout.HelpBox("target transform does not have MeshFilter component", MessageType.Error);
			}else if(GUILayout.Button("Convert")) target.Convert();

			if(target.isConverted == true){
				
				EditorGUILayout.LabelField("Coupled Tris Count: " + target.coupledTris.Length.ToString());
				
				//mesh zones
				EditorGUILayout.Space();
				EditorGUILayout.LabelField("Mesh Zones", headerStyle);
				
				EditorGUILayout.PropertyField(zonesSizeProp, false);
				if(GUILayout.Button("Create Zones")) target.CreateZones();
				EditorGUILayout.LabelField("Mesh Zones Count: " + target.meshZones.Count.ToString());
				
				if(target.meshZones.Count != 0){
//					EditorGUILayout.BeginHorizontal();{
						
						for(int i = 0; i < target.meshZones.Count; i++){
							EditorGUILayout.BeginVertical();{

							EditorGUILayout.BeginHorizontal();{
								target.meshZones[i].showZone = EditorGUILayout.Foldout(target.meshZones[i].showZone,
									target.meshZones[i].zoneName);
								target.meshZones[i].zoneColor = EditorGUILayout.ColorField(target.meshZones[i].zoneColor);
								EditorGUILayout.LabelField("Zone Tris Count: " + target.meshZones[i].zoneTris.Count.ToString());
								
							}EditorGUILayout.EndHorizontal();

//								if(target.meshZones[i].showZone){
//									EditorGUILayout.BeginHorizontal();{
										
//										EditorGUILayout.LabelField(target.meshZones[i].zoneName, GUILayout.Width(100));
										
//									}EditorGUILayout.EndHorizontal();
									
									//EditorGUILayout.LabelField("Zone Tris Count: " + target.meshZones[i].zoneTris.Count.ToString());
									
//									target.meshZones[i].showZoneTris = EditorGUILayout.Foldout(target.meshZones[i].showZoneTris, 
//										"Zone Tris count: " + target.meshZones[i].zoneTris.Count.ToString());
							if(target.meshZones[i].showZone){
								
								if(target.meshZones[i].zoneTris.Count != 0){
									
									for(int j = 0; j < target.meshZones[i].zoneTris.Count; j++){
										EditorGUILayout.LabelField(target.meshZones[i].zoneTris[j].triName);
									}
									
								}else EditorGUILayout.HelpBox("There's no zone tris assigned yet", MessageType.Error);

							}
								
								
							}EditorGUILayout.EndVertical();

						}
//					}EditorGUILayout.EndHorizontal();
					
					//Active Zone
					EditorGUILayout.Space();
					EditorGUILayout.LabelField("Active Zone", headerStyle);
					
					target.SetActiveZone(GUILayout.Toolbar(target.activeZoneIndex, target.toolBarStrings));
					
					
					if(target.activeZone != null){
						
						EditorGUILayout.BeginVertical();{
							
//							EditorGUILayout.LabelField(target.activeZone.index.ToString());
							EditorGUILayout.BeginHorizontal();{

								EditorGUILayout.LabelField(target.activeZone.zoneName.ToString(), GUILayout.MaxWidth(100));
								EditorGUILayout.ColorField(target.activeZone.zoneColor, GUILayout.MinWidth(100));
								EditorGUILayout.LabelField("active zone tris count: " + target.activeZone.zoneTris.Count.ToString());
								
							}EditorGUILayout.EndHorizontal();
							for(int i = 0; i < target.activeZone.zoneTris.Count; i++){
								EditorGUILayout.LabelField(target.activeZone.zoneTris[i].triName.ToString());
							}

						}EditorGUILayout.EndVertical();

					}else EditorGUILayout.HelpBox("Active Zone is not set", MessageType.Error);
					
				}else EditorGUILayout.HelpBox("There's no Mesh Zones created", MessageType.Error);
				
			}else EditorGUILayout.HelpBox("target trans not converted", MessageType.Error);
		}

		if(EditorGUI.EndChangeCheck())
		serializedObject.ApplyModifiedProperties();
	}

	void OnSceneGUI(){
		//get target's CoupledTris array
		//iterate through the array to find the mouseover tri
		//a) whose screenspace coord contains mousePos
		//b) if multiple tris are returned, select the one that is closest to camera pos
		//
		//clicking on the mouseover tri marks it as "Selected"
		//shift-Clike to DeSelect
		//
		//Draw suitable handles to represent various vectors and indeices of the selected tris




		Event curEv = Event.current; 
		MeshDataClass myTarget = (MeshDataClass)target;
		int controlID = GUIUtility.GetControlID(FocusType.Passive);
		Camera curCam = Camera.current;

		if(curCam == null || myTarget.coupledTris == null) return;
		CoupledTri mouseOverTri = GetMouseOverTri(myTarget.coupledTris, curEv, curCam);
		GUIStyle newStyle = new GUIStyle();
		newStyle.richText = true;

		if(myTarget.isReady){
			#region Control Switch
			//This switch controls input behaviour when the target gameobject is selected
			//in the hierarchy
			switch (curEv.GetTypeForControl (controlID)) {
			case EventType.MouseDown:
				GUIUtility.hotControl = controlID;

				//CheckForPositions(curEv.mousePosition);
				curEv.Use ();
				break;
			case EventType.MouseUp:
				GUIUtility.hotControl = 0;
				if(curEv.modifiers == EventModifiers.Shift){
					if(myTarget.activeZone.zoneTris.Contains(mouseOverTri))
						myTarget.activeZone.zoneTris.Remove(mouseOverTri);

					Debug.Log("shift click");
					curEv.Use();
					break;
				}

				if(!myTarget.activeZone.zoneTris.Contains(mouseOverTri) || myTarget.activeZone.zoneTris.Count == 0){
					if(mouseOverTri.triName!= "ng")
					myTarget.activeZone.zoneTris.Add(mouseOverTri);
				}
				Debug.Log ("click");

				curEv.Use ();
				break;
			case EventType.MouseDrag:
				GUIUtility.hotControl = controlID;
				//CheckForPositions(curEv.mousePosition);

				curEv.Use ();
				break;
			case EventType.KeyDown:
				if (curEv.keyCode == KeyCode.Escape) {
					// Do something on pressing Escape
				}
				if (curEv.keyCode == KeyCode.Space) {
					// Do something on pressing Spcae
				}
				if (curEv.keyCode == KeyCode.S) {
					// Do something on pressing S
				}
				break;
			case EventType.layout:
				HandleUtility.AddDefaultControl (controlID);
				break;
			}
			#endregion


			//drawing hover tri
			if(mouseOverTri.triName!= "ng"){
				Handles.Label(mouseOverTri.centroid, "<color=#ffffffff>" + mouseOverTri.triIndex.ToString() + "</color>", newStyle);
				Color newColor = Color.blue;
				newColor.a *= .2f;
				Handles.color = newColor;

				Handles.DrawAAConvexPolygon(mouseOverTri.p0, mouseOverTri.p1, mouseOverTri.p2);
			}

			//drawing zones tris
			if(myTarget.meshZones.Count != 0){
				
				for(int i = 0; i< myTarget.meshZones.Count; i++){

					Handles.color = myTarget.meshZones[i].zoneColor;

					if(myTarget.meshZones[i].zoneTris.Count != 0)

						for(int j = 0; j < myTarget.meshZones[i].zoneTris.Count; j++){
							Handles.DrawAAConvexPolygon
								(myTarget.meshZones[i].zoneTris[j].p0,
								myTarget.meshZones[i].zoneTris[j].p1,
								myTarget.meshZones[i].zoneTris[j].p2);
						}
				}
			}

			Handles.BeginGUI();
			GUILayout.BeginVertical();
			GUILayout.Button("Button", GUILayout.Width(100));//it's here for some button action...remove if you don't need
			GUILayout.Label("Mesh Zones Count: " + myTarget.meshZones.Count.ToString());
			for(int i = 0; i < myTarget.meshZones.Count; i++){
				GUILayout.Label("Mesh Zone " + i + " zone tris count: " + myTarget.meshZones[i].zoneTris.Count.ToString());
			}
			GUILayout.EndVertical();
			Handles.EndGUI();
		}
	
		#region alternative switch
//switch (curEv.type)
//		{
//		case EventType.mouseUp:
//
////			this works
////			Debug.Log("mousepos" + curEv.mousePosition/*TopLeft is 0, 0 */);
////			Vector3 targetPos = curCam.WorldToScreenPoint(myTarget.trans.position);
////			Vector2 correctedPos = new Vector2(targetPos.x, curCam.pixelHeight - targetPos.y);
//			//Debug.Log("targetPos" + correctedPos);
//
//			//Debug.Log("Hi");
//
//			curEv.Use();
//			break;
//
//		case EventType.layout:
//			
//			HandleUtility.AddDefaultControl(controlID);
//
//			break;
//		}
		#endregion





		if(GUI.changed) EditorUtility.SetDirty(myTarget);

	}


	[MenuItem("CONTEXT/MeshDataClass/Convert")]
	static void Convert(MenuCommand menuComm){
		MeshDataClass component = (MeshDataClass)menuComm.context;
		component.Convert();
	}

	[MenuItem("CONTEXT/MeshDataClass/CreateZones")]
	static void CreateZones(MenuCommand menuComm){
		MeshDataClass component = (MeshDataClass)menuComm.context;
		component.CreateZones();
	}
		
//	[MenuItem("CONTEXT/MeshDataClass/Set Active Zone")]
//	static void SetActiveZone(MenuCommand menuComm){
//		MeshDataClass component = (MeshDataClass)menuComm.context;
//		component.SetActiveZone();
//	}

	CoupledTri GetMouseOverTri(CoupledTri[] tris, Event evt, Camera cam){
		Vector2 mousePos = evt.mousePosition;
		CoupledTri prev = new CoupledTri();
		prev.centroid = cam.transform.position*100000000;
		prev.triName = "ng";
		List<CoupledTri> containingTris = new List<CoupledTri>();

		for(int i = 0; i < tris.Length; i ++){

			Vector3 p0 = cam.WorldToScreenPoint(tris[i].p0);
			Vector3 p1 = cam.WorldToScreenPoint(tris[i].p1);
			Vector3 p2 = cam.WorldToScreenPoint(tris[i].p2);

			float x0 = p0.x; float y0 = cam.pixelHeight - p0.y;
			float x1 = p1.x; float y1 = cam.pixelHeight - p1.y;
			float x2 = p2.x; float y2 = cam.pixelHeight - p2.y;


			float x = mousePos.x; float y = mousePos.y;

			float s = (((y1-y2)*(x-x2)) + ((x2-x1)*(y-y2))) / (((y1-y2)*(x0-x2)) + ((x2 - x1)*(y0-y2)));
			float t = (((y2-y0)*(x-x2)) + ((x0-x2)*(y-y2))) / (((y1-y2)*(x0-x2)) + ((x2 - x1)*(y0-y2)));


			if(s>=0f && s<=1f && t>=0f && t<=1f && s+t<=1f){
				containingTris.Add(tris[i]);
			}
		}

		if(containingTris.Count >=1){
			for(int j = 0; j<containingTris.Count; j++){
				prev = (cam.transform.position - containingTris[j].centroid).sqrMagnitude <= (cam.transform.position - prev.centroid).sqrMagnitude ? containingTris[j] : prev;
			}
		}
		return prev;
	}
}
		