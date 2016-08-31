using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomPropertyDrawer(typeof(Ingredient))]
public class IngredientDrawer : PropertyDrawer {

		//Draw th property inside the given rect
	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label){
		//Using BeginProperty/EncProperty on the parent property means that 
		//prefab override logic works on the entire property.
		EditorGUI.BeginProperty(pos,label, prop);

		//Draw label
		pos = EditorGUI.PrefixLabel(pos, GUIUtility.GetControlID(FocusType.Keyboard), label);

		//don't make child fields be indented
//
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		//Calculate Rects
		Rect amountRect = new Rect(pos.x, pos.y, 30, pos.height);
		Rect unitRect = new Rect(pos.x + 35, pos.y, 50, pos.height);
		Rect nameRect = new Rect(pos.x + 90, pos.y, pos.width - 90, pos.height);

		//Draw fields - pass GUIContents.none to each so they are drawn w/o labels
		EditorGUI.PropertyField(amountRect, prop.FindPropertyRelative("amount"), GUIContent.none);
		EditorGUI.PropertyField(unitRect, prop.FindPropertyRelative("unit"), GUIContent.none);
		EditorGUI.PropertyField(nameRect, prop.FindPropertyRelative("name"), GUIContent.none);

		//set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
