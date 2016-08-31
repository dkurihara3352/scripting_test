using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
//
public class InventoryItemListEditor : EditorWindow {

	public InventoryItemList inventoryItemList;
	private int viewIndex = 1;

	[MenuItem("Window/Custom/Inventory Item List Editor")]
	static void ShowWindow(){

		EditorWindow.GetWindow(typeof(InventoryItemListEditor));
	}

	void OnEnable(){
		//Loading previously saved Item List
		if(EditorPrefs.HasKey("ObjectPath")){
			string objectPath = EditorPrefs.GetString("ObjectPath");
			inventoryItemList = AssetDatabase.LoadAssetAtPath<InventoryItemList>(objectPath);
		}
	}

	void OnGUI(){
		GUILayout.BeginHorizontal();
			GUILayout.Label("Inventory Item List Editor", EditorStyles.boldLabel);
			if(inventoryItemList != null){
				if(GUILayout.Button("Show Item List")){
					EditorUtility.FocusProjectWindow();
					Selection.activeObject = inventoryItemList;
				}
			}
			if(GUILayout.Button("Open Item List")){
				OpenItemList();
			}
			if(GUILayout.Button("New Item List")){
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = inventoryItemList;
			}
		GUILayout.EndHorizontal();

		if(inventoryItemList == null){
			GUILayout.BeginHorizontal();
				GUILayout.Space(10);
				if(GUILayout.Button("Create New Item List", GUILayout.ExpandWidth(false))){
					CreateNewItemList();
				}
				if(GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false))){
					OpenItemList();
				}
			GUILayout.EndHorizontal();
		}

		GUILayout.Space(20);

		if(inventoryItemList != null){
			GUILayout.BeginHorizontal();
				GUILayout.Space(10);
				if(GUILayout.Button("Prev", GUILayout.ExpandWidth(false))){
					if(viewIndex > 1)
						viewIndex --;
				}
				GUILayout.Space(5);
				if(GUILayout.Button("Next", GUILayout.ExpandWidth(false))){
					if(viewIndex < inventoryItemList.itemList.Count){
						viewIndex ++;
					}
				}
				GUILayout.Space(60);
				if(GUILayout.Button("Add Item", GUILayout.ExpandWidth(false))){
					AddItem();
				}
				if(GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false))){
					DeleteItem(viewIndex - 1);
				}
			GUILayout.EndHorizontal();

			if(inventoryItemList.itemList ==null) Debug.Log("There's nothing in the list");
			if(inventoryItemList.itemList.Count >0){
				GUILayout.BeginHorizontal();
					viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, inventoryItemList.itemList.Count);
					EditorGUILayout.LabelField("of " + inventoryItemList.itemList.Count.ToString() + " items", "", GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal();

				inventoryItemList.itemList[viewIndex -1].itemName = 
					EditorGUILayout.TextField("Item Name", (string)inventoryItemList.itemList[viewIndex-1].itemName);
				inventoryItemList.itemList[viewIndex -1].itemIcon = 
					(Texture2D)EditorGUILayout.ObjectField("Item Icon",inventoryItemList.itemList[viewIndex -1].itemIcon,typeof(Texture2D), false);
				inventoryItemList.itemList[viewIndex -1].itemObject = 
					(Rigidbody)EditorGUILayout.ObjectField("Item Object", inventoryItemList.itemList[viewIndex -1].itemObject, typeof(Rigidbody), false);

				GUILayout.Space(10);

				GUILayout.BeginHorizontal();
					inventoryItemList.itemList[viewIndex -1].isUnique = 
						EditorGUILayout.Toggle("Unique", inventoryItemList.itemList[viewIndex -1].isUnique, GUILayout.ExpandWidth(false));
					inventoryItemList.itemList[viewIndex -1].isIndestructible = 
						EditorGUILayout.Toggle("Indestructible", inventoryItemList.itemList[viewIndex -1].isIndestructible, GUILayout.ExpandWidth(false));
					inventoryItemList.itemList[viewIndex -1].isQuestItem = 
						EditorGUILayout.Toggle("QuestItem", inventoryItemList.itemList[viewIndex -1].isQuestItem, GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				GUILayout.BeginHorizontal();
					inventoryItemList.itemList[viewIndex -1].isStackable = 
						EditorGUILayout.Toggle("Stackable", inventoryItemList.itemList[viewIndex -1].isStackable, GUILayout.ExpandWidth(false));
					inventoryItemList.itemList[viewIndex -1].isDestroyedOnUse = 
						EditorGUILayout.Toggle("Destroyed On Use", inventoryItemList.itemList[viewIndex -1].isDestroyedOnUse, GUILayout.ExpandWidth(false));
					inventoryItemList.itemList[viewIndex -1].encumbranceValue = 
						EditorGUILayout.FloatField("Encumbrance", inventoryItemList.itemList[viewIndex -1].encumbranceValue, GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal();

				GUILayout.Space(10);
			}
			else{
				GUILayout.Label("This Inventory List is Empty");
			}

		}
		if(inventoryItemList && GUI.changed){
			EditorUtility.SetDirty(inventoryItemList);
		}

	}

	void CreateNewItemList(){
		viewIndex = 1;
		inventoryItemList = CreateInventoryItemList.Create();
		if(inventoryItemList)
		{
			inventoryItemList.itemList = new List<InventoryItem>();
			string relPath = AssetDatabase.GetAssetPath(inventoryItemList);
			EditorPrefs.SetString("ObjectPath", relPath);
		}
	}

	void OpenItemList(){
		string absPath = EditorUtility.OpenFilePanel("Select Inventory Item List", "", "");
		if (absPath.StartsWith(Application.dataPath)){
			string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
			inventoryItemList = (InventoryItemList)AssetDatabase.LoadAssetAtPath(relPath, typeof(InventoryItemList));
			if(inventoryItemList.itemList == null)
				inventoryItemList.itemList = new List<InventoryItem>();
			if(inventoryItemList){
				EditorPrefs.SetString("ObjectPath", relPath);
			}
		}
	}

	void AddItem(){
				InventoryItem newItem = new InventoryItem();
				newItem.itemName = "New Item";
				inventoryItemList.itemList.Add(newItem);
				viewIndex = inventoryItemList.itemList.Count;
	}

	void DeleteItem(int index){
				inventoryItemList.itemList.RemoveAt(index);
	}
}
