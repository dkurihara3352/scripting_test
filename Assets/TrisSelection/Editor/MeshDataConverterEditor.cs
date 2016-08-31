using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(MeshDataConverterScr))]
public class MeshDataConverterEditor : Editor{

	#region fields
		// Transform targetTrans;
		MeshZone mouseOverZone;

		//initialized in OnEnable
			SerializedProperty transProp;
			GUIStyle newStyle;
			GUIStyle headerStyle;
			GUIStyle toggleButtonUp;
			GUIStyle toggleButtonDown;
			Color hoverTriFillCol;
			Color hoverTriOutlineCol;
			Color hoverLabelCol;
			Color hoverZoneFillCol;
			Color hoverZoneGroupFillCol;

			SerializedObject serializedMDObj;
	#endregion

	void OnEnable(){
		
		newStyle = new GUIStyle();
		newStyle.richText = true;
		headerStyle = new GUIStyle();
		headerStyle.fontStyle = FontStyle.Bold;

		hoverTriFillCol = Color.blue; hoverTriFillCol.a *= .2f;	
		hoverTriOutlineCol = hoverTriFillCol; hoverTriOutlineCol.a = 255f;
		hoverLabelCol = Color.white;
		hoverZoneFillCol = Color.red;
		hoverZoneFillCol.a *= .2f;
		hoverZoneGroupFillCol = hoverZoneFillCol;
		hoverZoneGroupFillCol.a *= .5f;
		transProp = serializedObject.FindProperty ("targetTrans");

	}
	public override void OnInspectorGUI(){
		//initialization for gui styles need to be done in here
			toggleButtonUp = new GUIStyle("Button");
			toggleButtonDown = new GUIStyle("Button");
			toggleButtonDown.normal.background = toggleButtonDown.active.background;
			serializedObject.Update();
		

		EditorGUI.BeginChangeCheck();{
			
			MeshDataConverterScr targetConverter = (MeshDataConverterScr)serializedObject.targetObject;

			//Beginning Converter Section
				EditorGUILayout.Space();
				EditorGUILayout.LabelField("Converter", headerStyle);
				int curInd = EditorGUI.indentLevel;
				EditorGUI.indentLevel ++;

				EditorGUILayout.PropertyField (transProp, false);
				targetTrans = targetConverter.targetTrans;

			#region After target trans is assigned
			if (targetTrans != null) {

				#region After the target trans is properly set
				if (targetTrans.gameObject.isStatic && targetTrans.gameObject.GetComponent<MeshFilter> () != null) {
					
					#region Asset Conversion
					targetConverter.assetName = EditorGUILayout.TextField ("Asset Name", targetConverter.assetName);

					EditorGUI.BeginDisabledGroup(String.IsNullOrEmpty(targetConverter.assetName));
					if (GUILayout.Button ("Create MeshData")){
						MeshDataObject namedAsset = (MeshDataObject)AssetDatabase.LoadAssetAtPath("Assets/" + targetConverter.assetName +".asset",
							typeof(MeshDataObject));
						if(namedAsset){
							targetConverter.showAlreadyUsedError = true;
						}else{
							targetConverter.showAlreadyUsedError = false;
							targetConverter.isAssetNameValid = true;
							CreateMeshDataObject (targetConverter.assetName);
						}
					}
					EditorGUI.EndDisabledGroup();
					if(targetConverter.showAlreadyUsedError)EditorGUILayout.HelpBox("The asset name is already used", MessageType.Error);
					#endregion

					#region After Asset name is correctly fed
					if(targetConverter.isAssetNameValid){
					}
					#endregion



				} else if (!targetTrans.gameObject.isStatic)
					EditorGUILayout.HelpBox ("Target Trans is not set static", MessageType.Error);
				else if (targetTrans.gameObject.GetComponent<MeshFilter> () == null)
					EditorGUILayout.HelpBox ("Target Trans does not have a mesh filter component", MessageType.Error);
				#endregion



			} else
				EditorGUILayout.HelpBox ("No Target Trans assigned", MessageType.Error);
			#endregion

			//Beginning Mesh Data Editor Section
			EditorGUI.indentLevel = curInd;

			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Mesh Data Editor", headerStyle);
			EditorGUI.indentLevel ++;

			targetConverter.meshData = (MeshDataObject)EditorGUILayout.ObjectField ("MeshData to edit", targetConverter.meshData, typeof(MeshDataObject), false);
			#region After Mesh Data is assigned
			if (targetConverter.meshData != null) {

				serializedMDObj = new UnityEditor.SerializedObject(targetConverter.meshData);
				serializedMDObj.Update();
				//							targetMeshData = (MeshDataObject)serializedMDObj.targetObject;

				targetConverter.isReady = EditorGUILayout.Toggle ("Mesh Data ready for scene editing", targetConverter.isReady);

				#region Zones
				EditorGUILayout.Space ();
				EditorGUILayout.LabelField ("Mesh Zones", headerStyle);

				targetConverter.zonesToCreate = EditorGUILayout.IntField ("number of zones to create: ", targetConverter.zonesToCreate);
				Undo.RecordObject (serializedObject.targetObject, "myInspector");

				if (targetConverter.zonesToCreate != 0) {
					if (GUILayout.Button ("Create Zones", GUILayout.MaxWidth (200))) {
						CreateZones (targetConverter.zonesToCreate, targetConverter);	
					}
				}

				#region Zone Display
				if (targetConverter.meshData.meshZones != null && targetConverter.meshData.meshZones.Count != 0) {
					targetConverter.showAllZones = EditorGUILayout.Foldout(targetConverter.showAllZones, 
						"Show All " + targetConverter.meshData.meshZones.Count.ToString() +  " Zones");
					if(targetConverter.showAllZones){
						for (int i = 0; i < targetConverter.meshData.meshZones.Count; i++) {
							EditorGUILayout.BeginVertical ();
							{
								EditorGUILayout.BeginHorizontal ();
								{
									targetConverter.meshData.meshZones [i].showZone = EditorGUILayout.Foldout (targetConverter.meshData.meshZones [i].showZone,
										targetConverter.meshData.meshZones [i].zoneName);
									targetConverter.meshData.meshZones [i].zoneColor = EditorGUILayout.ColorField (targetConverter.meshData.meshZones [i].zoneColor);
									Undo.RecordObject (serializedObject.targetObject, "myInpector");
									EditorGUILayout.LabelField ("Zone Tris Count: " + targetConverter.meshData.meshZones [i].zoneTris.Count.ToString ());	
								}
								EditorGUILayout.EndHorizontal ();

								if (targetConverter.meshData.meshZones [i].showZone) {

									if (targetConverter.meshData.meshZones [i].zoneTris.Count != 0) {

										for (int j = 0; j < targetConverter.meshData.meshZones [i].zoneTris.Count; j++) {
											EditorGUILayout.LabelField (targetConverter.meshData.meshZones [i].zoneTris [j].triName);
										}

									} else EditorGUILayout.HelpBox ("There's no zone tris assigned yet", MessageType.Error);
								}
							}EditorGUILayout.EndVertical ();
						}
					}
				} else EditorGUILayout.HelpBox ("There's no zones created", MessageType.Error);
			
				#endregion
				#endregion


				#region After mesh zones are correctly set
				if(targetConverter.meshData.meshZones != null){
					#region ActiveZone

					EditorGUILayout.Space ();
					EditorGUILayout.LabelField ("Active Zone", headerStyle);

					#region Prev&Next Buttons
					EditorGUILayout.BeginHorizontal();{
						// prev. cur. next
						EditorGUI.BeginDisabledGroup(targetConverter.activeZoneIndex <= 0);{
							if(GUILayout.Button("Prev")){targetConverter.activeZoneIndex--;}
						}EditorGUI.EndDisabledGroup();

						targetConverter.activeZoneIndex = EditorGUILayout.IntField(targetConverter.activeZoneIndex, GUILayout.MaxWidth(50f));
						EditorGUILayout.LabelField(" of " + targetConverter.meshData.meshZones.Count.ToString() + " Zones", GUILayout.MaxWidth(100f));

						EditorGUI.BeginDisabledGroup(targetConverter.activeZoneIndex >= targetConverter.meshData.meshZones.Count -1);{
							if(GUILayout.Button("Next")){targetConverter.activeZoneIndex++;}
						}EditorGUI.EndDisabledGroup();

					}EditorGUILayout.EndHorizontal();
					#endregion

					if (targetConverter.toolBarStrings != null)
						SetActiveZone (GUILayout.Toolbar (targetConverter.activeZoneIndex, targetConverter.toolBarStrings), 
							targetConverter);

					if (targetConverter.activeZone != null) {

						EditorGUILayout.BeginVertical ();
						{
							EditorGUILayout.BeginHorizontal ();
							{
								EditorGUILayout.LabelField (targetConverter.activeZone.zoneName.ToString (), GUILayout.MaxWidth (100));
								EditorGUILayout.ColorField (targetConverter.activeZone.zoneColor, GUILayout.MinWidth (100));
								EditorGUILayout.LabelField ("active zone tris count: " + targetConverter.activeZone.zoneTris.Count.ToString ());
							}
							EditorGUILayout.EndHorizontal ();

							targetConverter.showActiveZoneTris = EditorGUILayout.Foldout(targetConverter.showActiveZoneTris,
								"Show All " + targetConverter.activeZone.zoneTris.Count + " active zone tris");

							if(targetConverter.showActiveZoneTris){
								for (int i = 0; i < targetConverter.activeZone.zoneTris.Count; i++) {
									EditorGUILayout.LabelField (targetConverter.activeZone.zoneTris [i].triName.ToString ());
								}
							}
						}
						EditorGUILayout.EndVertical ();
					} else
						EditorGUILayout.HelpBox ("Active Zone is not set", MessageType.Error);
					#endregion

					//Creating Adjuscent Zones
					if (GUILayout.Button ("Create Zone Group")) {
						CreateZoneGroup (targetConverter.meshData);
					}

					//Controls for meshData scene display
					EditorGUILayout.BeginHorizontal ();
					{
						if (GUILayout.Button (targetConverter.showAllZoneTris ? "Show All Zone Tris: On" : "Show All Zones Tris: Off",
							targetConverter.showAllZoneTris ? toggleButtonDown : toggleButtonUp)) {
							targetConverter.showAllZoneTris = !targetConverter.showAllZoneTris;
						}
						if (GUILayout.Button (targetConverter.showNTB ? "Show N, T, B: On" : "Show N, T, B: Off", targetConverter.showNTB ? toggleButtonDown : toggleButtonUp)) {
							targetConverter.showNTB = !targetConverter.showNTB;
						}

						if (GUILayout.Button (targetConverter.showNTB ? "Show AZ Tri: On" : "Show AZ Tri: Off", 
							targetConverter.showAZTrisOnScene ? toggleButtonDown : toggleButtonUp)) {
							targetConverter.showAZTrisOnScene = !targetConverter.showAZTrisOnScene;
						}

					}
					EditorGUILayout.EndHorizontal ();

				}
				#endregion

			}
			#endregion

		}if(EditorGUI.EndChangeCheck()){
			
			serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(serializedObject.targetObject);
			if(serializedMDObj != null){
				serializedMDObj.ApplyModifiedProperties();
				EditorUtility.SetDirty(serializedMDObj.targetObject);
			}
		}
	}

	void OnSceneGUI(){
		
		serializedObject.Update();
		EditorGUI.BeginChangeCheck();{
		
			Event curEv = Event.current; 
			MeshDataConverterScr targetConverter = (MeshDataConverterScr)serializedObject.targetObject;
			MeshDataObject targetMeshData = targetConverter.meshData;
			int controlID = GUIUtility.GetControlID(FocusType.Passive);
			Camera curCam = Camera.current;
			if(targetMeshData == null)return;


			if(targetConverter.isReady){
				CoupledTri mouseOverTri = GetMouseOverTri(targetMeshData.coupledTris, curEv, curCam);
				if(targetMeshData.meshZones.Count != 0)
					mouseOverZone = GetMouseOverZone(mouseOverTri, targetMeshData.meshZones);
				
				#region Control Switch
				//This switch controls input behaviour when the target gameobject is selected
				//in the hierarchy
				switch (curEv.GetTypeForControl (controlID)) {
				case EventType.MouseDown:
					GUIUtility.hotControl = controlID;
					curEv.Use ();
					break;
				case EventType.MouseUp:
					GUIUtility.hotControl = 0;
					curEv.Use ();
					break;
				case EventType.MouseDrag:
					GUIUtility.hotControl = controlID;
					if(curEv.modifiers == EventModifiers.Shift){
						if(targetConverter.activeZone.zoneTris.Contains(mouseOverTri))
							targetConverter.activeZone.zoneTris.Remove(mouseOverTri);
							curEv.Use();
							break;
					}
					if(curEv.modifiers == EventModifiers.Control){
						if(!targetConverter.activeZone.zoneTris.Contains(mouseOverTri) || targetConverter.activeZone.zoneTris.Count == 0){
							if(mouseOverTri.triName!= "ng")
								targetConverter.activeZone.zoneTris.Add(mouseOverTri);
						}
					}

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

				#region Drawing Hover Tri
				if (mouseOverTri.triName != "ng") {

					Handles.color = hoverTriFillCol;
					Handles.DrawAAConvexPolygon (mouseOverTri.p0, mouseOverTri.p1, mouseOverTri.p2);

					Handles.color = hoverTriOutlineCol;
					Handles.DrawAAPolyLine (mouseOverTri.p0, mouseOverTri.p1, mouseOverTri.p2, mouseOverTri.p0);

					Handles.color = hoverLabelCol;
					Handles.Label (mouseOverTri.centroid,mouseOverTri.triIndex.ToString ());
					Handles.Label (mouseOverTri.p0, "p0: " + mouseOverTri.p0uv.x.ToString () + ", " + mouseOverTri.p0uv.y.ToString ());
					Handles.Label (mouseOverTri.p1, "p1: " + mouseOverTri.p1uv.x.ToString () + ", " + mouseOverTri.p1uv.y.ToString ());
					Handles.Label (mouseOverTri.p2, "p2: " + mouseOverTri.p2uv.x.ToString () + ", " + mouseOverTri.p2uv.y.ToString ());
				}
				#endregion

				#region Drawing hover zone and adjuscent zones
				if (mouseOverTri.triName != "ng" && mouseOverZone != null) {

					//drawing hover zone
					for (int i = 0; i < mouseOverZone.zoneTris.Count; i++) {
						Handles.color = hoverZoneFillCol;
						Handles.DrawAAConvexPolygon (mouseOverZone.zoneTris [i].p0, mouseOverZone.zoneTris [i].p1, mouseOverZone.zoneTris [i].p2);
					}

					//drawing member zones
					if (targetMeshData.zoneGroup.Count != 0) {
						Handles.color = hoverZoneGroupFillCol;
						for (int i = 0; i < GetMemberZone (mouseOverZone, targetMeshData).Count; i++) {
							for (int j = 0; j < GetMemberZone (mouseOverZone, targetMeshData) [i].zoneTris.Count; j++) {
								Handles.DrawAAConvexPolygon (GetMemberZone (mouseOverZone, targetMeshData) [i].zoneTris [j].p0,
									GetMemberZone (mouseOverZone, targetMeshData) [i].zoneTris [j].p1,
									GetMemberZone (mouseOverZone, targetMeshData) [i].zoneTris [j].p2);
							}
						}
					}
				}

				#endregion
					
				#region Drawing All Zones Tris
				if (targetConverter.showAllZoneTris) {
					if (targetMeshData.meshZones.Count != 0) {
						
						for (int i = 0; i < targetMeshData.meshZones.Count; i++) {
							
							if (targetMeshData.meshZones [i].zoneTris.Count != 0) {
								
								for (int j = 0; j < targetMeshData.meshZones [i].zoneTris.Count; j++) {
									Handles.color = targetMeshData.meshZones [i].zoneColor;
									Handles.DrawAAConvexPolygon
									(targetMeshData.meshZones [i].zoneTris [j].p0,
										targetMeshData.meshZones [i].zoneTris [j].p1,
										targetMeshData.meshZones [i].zoneTris [j].p2);
								}
							}
						}
					}
				}
				if (targetConverter.showNTB) {
					for (int i = 0; i < targetMeshData.meshZones.Count; i++) {

						if (targetMeshData.meshZones [i].zoneTris.Count != 0) {

							for (int j = 0; j < targetMeshData.meshZones [i].zoneTris.Count; j++) {
								
								Handles.color = Handles.xAxisColor;
								Handles.ArrowCap (-1, targetMeshData.meshZones [i].zoneTris [j].centroid, Quaternion.LookRotation (targetMeshData.meshZones [i].zoneTris [j].normal), .3f);
								
								Handles.color = Handles.yAxisColor;
								Handles.ArrowCap (-1, targetMeshData.meshZones [i].zoneTris [j].centroid, Quaternion.LookRotation (targetMeshData.meshZones [i].zoneTris [j].tangent), .3f);
								
								Handles.color = Handles.zAxisColor;
								Handles.ArrowCap (-1, targetMeshData.meshZones [i].zoneTris [j].centroid, Quaternion.LookRotation (targetMeshData.meshZones [i].zoneTris [j].binormal), .3f);
							}
						}
					}
				}
				#endregion

				#region Draw Active Zone Tris
				if (targetConverter.showAZTrisOnScene) {
					Handles.color = targetConverter.activeZone.zoneColor;
					for (int i = 0; i < targetConverter.activeZone.zoneTris.Count; i++) {
						Handles.DrawAAConvexPolygon (
							targetConverter.activeZone.zoneTris [i].p0,
							targetConverter.activeZone.zoneTris [i].p1,
							targetConverter.activeZone.zoneTris [i].p2);
					}
				}
				#endregion
					
				#region Show Overlay GUI
				Handles.BeginGUI ();
				{
					GUILayout.BeginArea (new Rect (10, 10, 300, 300));
					{
						//Buttons, toggles etc does not register appropriately
						GUILayout.Label ("Mesh Zones Count: " + targetMeshData.meshZones.Count.ToString ());
						for (int i = 0; i < targetMeshData.meshZones.Count; i++) {
							GUILayout.Label ("Mesh Zone " + i + " zone tris count: " + targetMeshData.meshZones [i].zoneTris.Count.ToString ());
						}
					}
					GUILayout.EndArea ();

				}
				Handles.EndGUI ();
				#endregion
			}
		}if(EditorGUI.EndChangeCheck()){
			serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(serializedObject.targetObject);
		}

	}
		
	void CreateMeshDataObject(string assetName){
		MeshDataObject obj = ScriptableObject.CreateInstance<MeshDataObject>();

		Convert(obj);

		AssetDatabase.CreateAsset(obj, "Assets/" + assetName + ".asset");
		AssetDatabase.Refresh();

	}

	void Convert(MeshDataObject obj){
		if(targetTrans.gameObject.GetComponent<MeshFilter>() == null) return;
		else{

			obj.objectName = targetTrans.gameObject.name;
			Mesh mesh = targetTrans.gameObject.GetComponent<MeshFilter>().sharedMesh;

			int[] tris = mesh.triangles;
			Vector3[] verts = mesh.vertices;
			obj.coupledTris = new CoupledTri[mesh.triangles.Length/3];

			for(int i = 0; i < tris.Length; i += 3){
				Vector3 p0 = verts[tris[i + 0]];
				Vector3 p2 = verts[tris[i + 1]];
				Vector3 p1 = verts[tris[i + 2]];
				p0 = targetTrans.TransformPoint(p0);
				p1 = targetTrans.TransformPoint(p1);
				p2 = targetTrans.TransformPoint(p2);


				Vector3 centroid = new Vector3((p0.x + p1.x + p2.x)/3, (p0.y + p1.y + p2.y)/3, (p0.z + p1.z + p2.z)/3);
				Vector2 p0uv = mesh.uv[tris[i + 0]];
				Vector2 p2uv = mesh.uv[tris[i + 1]];
				Vector2 p1uv = mesh.uv[tris[i + 2]];

				Vector3 udir = Vector3.zero;
				Vector3 vdir = Vector3.zero;



				if(p0uv.x == p1uv.x){
					if(p0uv.y > p1uv.y) vdir = (p0 -p1).normalized;
					else if(p0uv.y < p1uv.y)vdir = (p1 - p0).normalized;
					else Debug.Log("vertices UV incorrectly set");
				}
				else if(p1uv.x == p2uv.x){
					if(p1uv.y > p2uv.y) vdir = (p1 -p2).normalized;
					else if(p1uv.y < p2uv.y)vdir = (p2 - p1).normalized;
					else Debug.Log("vertices UV incorrectly set");
				}
				else if(p2uv.x == p0uv.x){
					if(p2uv.y > p0uv.y) vdir = (p2 -p0).normalized;
					else if(p2uv.y < p0uv.y)vdir = (p0 - p2).normalized;
					else Debug.Log("vertices UV incorrectly set");
				}

				if (p0uv.y == p1uv.y){
					if(p0uv.x > p1uv.x) udir = (p0 - p1).normalized;
					else if(p0uv.x < p1uv.x) udir = (p1 - p0).normalized;
					else Debug.Log("vertices UV incorrectly set");
				}
				else if (p1uv.y == p2uv.y){
					if(p1uv.x > p2uv.x) udir = (p1 - p2).normalized;
					else if(p1uv.x < p2uv.x) udir = (p2 - p1).normalized;
					else Debug.Log("vertices UV incorrectly set");

				}
				else if (p2uv.y == p0uv.y){
					if(p2uv.x > p0uv.x) udir = (p2 - p0).normalized;
					else if(p2uv.x < p0uv.x) udir = (p0 - p2).normalized;
					else Debug.Log("vertices UV incorrectly set");
				}

				Vector3 normal = Vector3.Cross(vdir, udir);
				Vector3 tangent = (udir == Vector3.zero)? Vector3.Cross(normal, vdir): udir;
				Vector3 binormal = (vdir == Vector3.zero)? Vector3.Cross(udir, normal): vdir;

				CoupledTri newTri = new CoupledTri();
				newTri.triIndex = i/3;
				newTri.triName = "tri " + (i/3).ToString();


				newTri.p0 = p0;
				newTri.p1 = p1;
				newTri.p2 = p2;
				newTri.centroid = centroid;
				newTri.uDir = udir;
				newTri.vDir = vdir;
				newTri.normal = normal;
				newTri.tangent = tangent;
				newTri.binormal = binormal;

				newTri.p0uv = p0uv;
				newTri.p1uv = p1uv;
				newTri.p2uv = p2uv;

				obj.coupledTris[i/3] = newTri;
				obj.isConverted = true;
				obj.zoneGroup = new List<MeshZoneList>();

			}
		}
	}

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

	MeshZone GetMouseOverZone(CoupledTri mouseOverTri, List<MeshZone> meshZones){
		for(int i = 0; i < meshZones.Count; i++){
			for(int j = 0; j < meshZones[i].zoneTris.Count; j++){
				if(meshZones[i].zoneTris[j].triIndex == mouseOverTri.triIndex){
					return meshZones[i];
				}
			}
		}

		return null;
	}

	void CreateZones(int num, MeshDataConverterScr converter){
		
		converter.meshData.meshZones = new List<MeshZone>();
		MeshZone.zonesSize = 0;
		converter.toolBarStrings = new string[num];
		converter.meshData.zoneGroup.Clear();
		for(int i = 0; i < num; i++){
			MeshZoneList newMeshZoneList = new MeshZoneList();
			newMeshZoneList.childMeshZones = new List<MeshZone>();
			converter.meshData.zoneGroup.Add(newMeshZoneList);
			MeshZone newMeshZone = new MeshZone();
			converter.meshData.meshZones.Add(newMeshZone);
			converter.toolBarStrings[i] = i.ToString();
		}
	}
		
	void SetActiveZone(int index, MeshDataConverterScr converterScr){
		if(converterScr.meshData.meshZones.Count != 0 && converterScr.activeZoneIndex!= -1){
			converterScr.activeZone = converterScr.meshData.meshZones[index];
			converterScr.activeZoneIndex = index;
		}else return;
	}

	void CreateZoneGroup(MeshDataObject dataObj){
		for(int i = 0; i < dataObj.meshZones.Count; i ++){
			for(int j = 0; j <dataObj.meshZones.Count; j ++){
				if(dataObj.meshZones[i].IsAdjescentTo(dataObj.meshZones[j]))
				dataObj.zoneGroup[i].childMeshZones.Add(dataObj.meshZones[j]);
			}
		}
	}

	List<MeshZone> GetMemberZone(MeshZone zone, MeshDataObject dataObj){
		return dataObj.zoneGroup[zone.index].childMeshZones;
	}
}













 
