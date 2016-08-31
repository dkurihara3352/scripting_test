using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyEditorWindow: EditorWindow, IHasCustomMenu {

	#region CustomMenu

	public void AddItemsToMenu (GenericMenu menu)
	{

		menu.AddItem (new GUIContent ("Custom Menu 1"), false, CustomMenuFunc, "1");
		menu.AddItem (new GUIContent ("Custom Menu 2"), true, CustomMenuFunc, "2");
		menu.AddSeparator(" ");
		menu.AddItem(new GUIContent( "Custom SubMenu/Custom Menu 3"), true, CustomMenuFunc, "3");
	}

	void CustomMenuFunc (object obj)
	{
		Debug.Log ("Custom Menu " + obj + " has been activated");
	}

	#endregion

	[MenuItem("Window/Custom/MyEditorWindow")]
	public static void Open(){
		GetWindow<MyEditorWindow>();
	}

	bool toggleValue;

	void OnGUI(){
		EditorGUILayout.LabelField("Example Label");
		EditorGUI.indentLevel++;

		EditorGUI.BeginChangeCheck();

		toggleValue = EditorGUILayout.ToggleLeft ("Toggle", toggleValue);

		EditorGUI.BeginDisabledGroup (true);//or, GUI.enabled = false;
		InsertSpace ();
		DisplayGUIBlock ();

		EditorGUI.EndDisabledGroup ();// or, GUI.enabled = true;

		InsertSpace ();
		DisplayObjectFields ();

		//DisplayMultiFloatField(); //Disable since overlapping
		InsertSpace();
		EditorGUILayout.BeginHorizontal();
		DisplayKnob();
		DisplayToggleButton();
		EditorGUILayout.EndHorizontal();

		InsertSpace();
		DisplayToggleButtons();


		if (EditorGUI.EndChangeCheck ()) {
			if (toggleValue) {
				Debug.Log ("toggleValue is true, and change detected");
			}
		}
	}

	void DisplayGUIBlock(){

		EditorGUILayout.ToggleLeft("Toggle", false);
		EditorGUILayout.IntSlider(0, 0, 10);
		GUILayout.Button("Button");

	}

	#region DisplayObjectField

	GameObject obj;
	Material mat;
	AudioClip ac;
	Texture2D tex;
	Sprite sp;

	void DisplayObjectFields ()
	{	
		EditorGUI.indentLevel--;
		EditorGUILayout.LabelField("Object Fields");
		EditorGUI.indentLevel++;
		obj = (GameObject)EditorGUILayout.ObjectField (obj, typeof(GameObject), false);
		mat = (Material)EditorGUILayout.ObjectField (mat, typeof(Material), false);
		ac = (AudioClip)EditorGUILayout.ObjectField (ac, typeof(AudioClip), false);
		EditorGUILayout.BeginHorizontal ();
		tex = (Texture2D)EditorGUILayout.ObjectField (tex, typeof(Texture2D), false, GUILayout.Width (64), GUILayout.Height (64));
		sp = (Sprite)EditorGUILayout.ObjectField (sp, typeof(Sprite), false, GUILayout.Width (64), GUILayout.Height (64));
		EditorGUILayout.EndHorizontal ();
	}

	#endregion

	void InsertSpace(){
		EditorGUILayout.Space();
	}

	#region MultiFloatField

	float[] numbers = new float[3] {
		0f, 1f, 2f
	};

	GUIContent[] contents = new GUIContent[] {
		new GUIContent ("X"),
		new GUIContent ("Y"),
		new GUIContent ("Z")
	};

	Rect rect = new Rect (30f, 30f, 200f, EditorGUIUtility.singleLineHeight);

	void DisplayMultiFloatField ()
	{
		EditorGUI.MultiFloatField (rect, new GUIContent ("Label"), contents, numbers);
	}

	#endregion

	#region DisplayKnob

	float angle;

	void DisplayKnob ()
	{
		EditorGUILayout.BeginVertical();
		EditorGUI.indentLevel--;
		EditorGUILayout.LabelField ("Knob");
		EditorGUI.indentLevel++;
		angle = EditorGUILayout.Knob (Vector2.one * 64, angle, 0f, 360f, "degree", Color.grey, Color.green, true);
		EditorGUILayout.EndVertical();
	}

	#endregion

	#region DisplayToggleButton

	bool isToggleButtonOn;

	void DisplayToggleButton ()
	{
		EditorGUILayout.BeginVertical ();
		EditorGUI.indentLevel--;
		EditorGUILayout.LabelField ("Toggle Button");
		isToggleButtonOn = EditorGUILayout.Toggle (new GUIContent(isToggleButtonOn ? "On" : "Off"), isToggleButtonOn, "Button");
		EditorGUILayout.EndVertical ();
	}

	#endregion

	#region DisplayToggleButtons

	int selectedIndex;

	void DisplayToggleButtons ()
	{
		EditorGUI.indentLevel = 0;
		EditorGUILayout.LabelField ("Toggle Buttons");
		EditorGUI.indentLevel++;
		selectedIndex = GUILayout.Toolbar (selectedIndex, new string[3]{ "0", "1", "2" });
	}

	#endregion
}
