using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
//[CreateAssetMenu(fileName = "InventoryItemList", menuName = "Custom/InventoryItemList", order = 3)] 
public class InventoryItemList : ScriptableObject {

	public List<InventoryItem> itemList;
}
