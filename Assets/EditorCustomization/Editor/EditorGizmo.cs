using UnityEngine;
using UnityEditor;

public class EditorGizmo{

	[DrawGizmo(GizmoType.NonSelected|GizmoType.Active)]
	static void DrawPlaceholderGizmos(GizmoPlaceholder scr, GizmoType gizType){

		Transform trans = scr.transform;
		Color32 col = new Color32(127, 255, 127, 127);

		if((gizType & GizmoType.Active) == GizmoType.Active){

			col.r = 0;
			col.b = 0;
			col.a = 255;
		}

		Gizmos.color = col;
		Gizmos.DrawWireCube(trans.position, trans.lossyScale);
	}
}
