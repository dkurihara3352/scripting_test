using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(TrisHolder))]
public class TrisHolderEditor : Editor {


	void OnEnable(){

	}

	void OnSceneGUI(){

		TrisHolder trisHolder = (TrisHolder)target;
		Event currentEvent = Event.current;
//		GUIContent myEditorHash = new GUIContent("WTFString");
//		int controlID = GUIUtility.GetControlID(myEditorHash, FocusType.Passive);
		int controlID = GUIUtility.GetControlID(FocusType.Passive);
	
//		RaycastToShowIndex(currentEvent);
		ShowTargetTransMeshIndex(trisHolder.targetMeshTransform);
		

		switch(currentEvent.type){
			case EventType.mouseUp:

			//Do something simple over here
//			Debug.Log(currentEvent.mousePosition);
			currentEvent.Use();
			break;

			case EventType.layout:
			HandleUtility.AddDefaultControl(controlID);
			break;


		}

		if(GUI.changed)
			EditorUtility.SetDirty(target);
	}


	void RaycastToShowIndex(Event cur){

		Event currentEvent = cur;
		Ray ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 1000) && hit.collider.GetType() == (typeof(MeshCollider))){
			Debug.Log("hit");
			MeshCollider meshCol = (MeshCollider)hit.collider;
			if(meshCol == null || meshCol.sharedMesh == null) return;

			Mesh mesh = meshCol.sharedMesh;
			Vector3[] verts = mesh.vertices;
			int[] tris = mesh.triangles;
			Vector3 p0 = verts[tris[hit.triangleIndex *3 + 0]];
			Vector3 p1 = verts[tris[hit.triangleIndex *3 + 1]];
			Vector3 p2 = verts[tris[hit.triangleIndex *3 + 2]];
			Transform hitTransform = hit.collider.transform;
			p0 = hitTransform.TransformPoint(p0);
			p1 = hitTransform.TransformPoint(p1);
			p2 = hitTransform.TransformPoint(p2);

			Handles.DrawLine(p0,p1);
			Handles.DrawLine(p1,p2);
			Handles.DrawLine(p2,p0);

			Vector3 centroid = new Vector3((p0.x + p1.x + p2.x)/3, (p0.y + p1.y + p2.y)/3, (p0.z + p1.z + p2.z)/3); 
			GUIStyle newStyle = new GUIStyle();
			newStyle.richText = true;
			//			Display Triangle Index in cyan
			Handles.Label(centroid, "<color=#00ffffff>" + hit.triangleIndex.ToString() +"</color>", newStyle);
			//display vertex index in green
			//			Handles.Label(p0, "<color=#00ff00ff>" + (hit.triangleIndex*3 +0).ToString() + "</color>", newStyle);
			//			Handles.Label(p1, "<color=#00ff00ff>" + (hit.triangleIndex*3 +1).ToString() + "</color>", newStyle);
			//			Handles.Label(p2, "<color=#00ff00ff>" + (hit.triangleIndex*3 +2).ToString() + "</color>", newStyle);
			for(int i = 0; i <verts.Length; i++){
				Handles.Label(hitTransform.TransformPoint(verts[i]), "<color=#add8e6ff>" + i.ToString() + "</color>", newStyle);
			}

		}
	}//End of RaycastToShowIndex

	void ShowTargetTransMeshIndex(Transform trans){

		if(trans == null)return;
		else{
			Mesh targetMesh = trans.gameObject.GetComponent<MeshFilter>().sharedMesh;
			int[] tris = targetMesh.triangles;
			Vector3[] verts = targetMesh.vertices;
			GUIStyle newStyle = new GUIStyle();
			newStyle.richText = true;

//			Debug.Log("Tris Count: " + tris.Length);
//			Debug.Log("Verts Count: " + verts.Length);
		

			//draw tri index
			for(int i = 0; i < tris.Length; i++){
				if(i %3 != 0)continue;
				Vector3 p0 = verts[tris[i + 0]];
				Vector3 p1 = verts[tris[i + 1]];
				Vector3 p2 = verts[tris[i + 2]];


				Vector3 centroid = new Vector3((p0.x + p1.x + p2.x)/3, (p0.y + p1.y + p2.y)/3, (p0.z + p1.z + p2.z)/3); 
				centroid = trans.TransformPoint(centroid);

				Handles.Label(centroid, "<color=#00ffffff>" + (i/3).ToString() + "</color>", newStyle);
			}
				

			//draw verts index
			for(int i = 0; i < verts.Length; i ++){
				Handles.Label(trans.TransformPoint(verts[i]), "<color=#add8e6ff>" + i.ToString() + "</color>", newStyle);
			}
		}

	}//End of ShowTargetTransMeshIndex

	public bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}



	public override void OnInspectorGUI(){
		//TrisHolder myTarget = (TrisHolder)target;
		DrawDefaultInspector(); 
	} 

}
