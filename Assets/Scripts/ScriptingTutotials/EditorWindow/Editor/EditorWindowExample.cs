using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorWindowExample : EditorWindow {

	string myString = "Hello World";
	bool isGroupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;



	[MenuItem("Window/Custom/Editor Window Example")]

	public static void ShowWindow(){
		EditorWindow.GetWindow(typeof(EditorWindowExample));
	}

	void OnGUI(){
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField("Text Field", myString);
		isGroupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", isGroupEnabled);
			myBool = EditorGUILayout.Toggle("Toggle", myBool);
			myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup();

		GUILayout.Button("Click");

//		GUILayout.BeginHorizontal("Horizontal Group");
		EditorGUILayout.BeginHorizontal();
			EditorGUILayout.HelpBox("Some message", MessageType.Info);
			EditorGUILayout.HelpBox("Some other message", MessageType.Info);
//		GUILayout.EndHorizontal();
		EditorGUILayout.EndHorizontal();

//		GUILayout.BeginVertical("Vertical Group");
		EditorGUILayout.BeginVertical();
			EditorGUILayout.HelpBox("These are aligned vertically", MessageType.Info);
			EditorGUILayout.HelpBox("This is stacked underneath", MessageType.Info);
//		GUILayout.EndVertical();
		EditorGUILayout.EndVertical();
//		Vector2 scrollPos = new Vector2(100,100);
//		string scrollString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean commodo nisl vitae tempus commodo. Etiam cursus dignissim convallis. Vestibulum hendrerit cursus velit eget placerat. Nullam elementum tempor auctor. Cras nec pulvinar mauris, aliquet varius nulla. In sed laoreet turpis. Maecenas magna arcu, ultricies eget interdum vel, feugiat eu risus. Sed eget enim vel nunc suscipit facilisis eu id risus. Cras vestibulum ex nunc, nec bibendum nisi fermentum non. Nam consectetur ultrices lorem ac malesuada. Interdum et malesuada fames ac ante ipsum primis in faucibus.\n\nIn quis nisl neque. Mauris eros nulla, euismod non lectus sed, semper luctus ligula. Morbi tristique nunc vitae tellus mattis congue. Phasellus a porttitor nulla. Fusce nisl urna, mollis eu justo nec, laoreet pretium odio. Fusce eu tempor turpis. Suspendisse potenti. Quisque egestas nisi at turpis interdum commodo. Phasellus quam nisi, lacinia ac condimentum quis, vestibulum vel dui. Suspendisse potenti. Praesent ullamcorper enim non porta porta. Integer id purus tincidunt ex malesuada mollis at vel erat. Vestibulum augue orci, pellentesque fringilla faucibus tempus, volutpat imperdiet eros. Proin nec dolor sit amet lectus venenatis posuere. Fusce consequat vulputate est, tristique accumsan odio pretium nec.\n\nVivamus vel lacus dolor. Aenean tincidunt neque in ultrices porta. Quisque eget nunc at arcu rutrum sagittis et eget nulla. Aenean accumsan augue in ante vestibulum, at fringilla ipsum pharetra. Duis bibendum at massa tempor vestibulum. Pellentesque tellus turpis, malesuada ut mi vel, blandit gravida elit. Pellentesque posuere eros sagittis, posuere metus at, auctor lorem. Donec eleifend velit id nisl luctus, in posuere orci tincidunt. Sed sagittis libero in nisl aliquam, ut dapibus erat condimentum.\n\nCras a pulvinar quam. Vivamus volutpat, metus et porttitor scelerisque, ex enim ullamcorper augue, sed posuere dui magna eu turpis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Maecenas id feugiat arcu. Nam ullamcorper posuere convallis. Sed eget purus dictum, malesuada mauris vitae, mollis nibh. Proin tincidunt luctus sapien, in pellentesque neque fermentum mollis. Nulla auctor ex elementum placerat varius. Praesent faucibus at leo in auctor.\n\nNam ultricies varius varius. Aliquam sit amet mollis augue. Nam dignissim vulputate turpis, a feugiat diam placerat nec. Integer sagittis dignissim viverra. Aenean dictum, nulla ut auctor consectetur, erat neque auctor erat, quis laoreet nibh mi sit amet justo. Praesent dapibus nibh eros, vitae facilisis dolor consectetur eget. Vivamus eu sollicitudin odio, sed porttitor mi. Ut convallis arcu at sagittis congue.";
//		EditorGUILayout.BeginScrollView(scrollPos, true, true);
//		GUILayout.Label(scrollString);
//		EditorGUILayout.EndScrollView();

	}
}
