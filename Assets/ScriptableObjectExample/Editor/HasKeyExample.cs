using UnityEngine;
using System.Collections;
using UnityEditor;


public class HasKeyExample : EditorWindow {

	string notes = "Notes: \n-> \n-> ";
	int sidesPadding = 5;
	int buttonsHeight = 30;
	float clearButtonWidthRatio = .4f;

	[MenuItem("Window/Custom/HasKeyExample")]
	public static void ShowWindow(){

		EditorWindow.GetWindow(typeof(HasKeyExample));
	}

	void OnGUI(){
		notes = EditorGUILayout.TextArea(notes, GUILayout.Width(position.width - sidesPadding), GUILayout.Height(position.height - buttonsHeight));
		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("Reset")) notes = "";
		if(GUILayout.Button("Clear Story",GUILayout.Width(position.width* clearButtonWidthRatio))) notes = "Notes: \n-> \n->";
		EditorGUILayout.EndHorizontal();
	}

	void OnFocus(){
		if(EditorPrefs.HasKey("QuickNotes")){

			notes = EditorPrefs.GetString("QuickNotes");
		}
	}

	void OnLostFocus(){

		EditorPrefs.SetString("QuickNotes", notes);
	}

	void OnDestroy(){

		EditorPrefs.SetString("QuickNotes", notes);
	}
}
