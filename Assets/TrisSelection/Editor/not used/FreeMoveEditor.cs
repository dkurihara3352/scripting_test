using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(FreeMove))]
public class FreeMoveEditor : Editor {

	public void OnSceneGUI(){
		FreeMove fm = (FreeMove)target;
		EditorGUI.BeginChangeCheck();
		Vector3 pos = Handles.FreeMoveHandle(fm.lookAtPoint, Quaternion.identity, .5f, new Vector3(.5f, .5f, .5f), Handles.RectangleCap);

//		Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
//		Debug.DrawRay(ray.origin, ray.direction *20, Color.yellow);

		if(EditorGUI.EndChangeCheck()){
			Undo.RecordObject(target, "Free_Move_LookAt_Point");
			fm.lookAtPoint = pos;
			fm.Update();
		}
	}
}
