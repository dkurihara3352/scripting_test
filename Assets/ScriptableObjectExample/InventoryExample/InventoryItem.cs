using UnityEngine;
using System.Collections;

[System.Serializable]
//[CreateAssetMenu(fileName = "Inventory Item", menuName = "Custom/Inventory Item", order = 2)]
public class InventoryItem {//what if this class inherits from scriptableObjectClass?

	public string itemName = "New Item";
	public Texture2D itemIcon = null;
	public Rigidbody itemObject =null;
	public bool isUnique = false;
	public bool isIndestructible = false;
	public bool isQuestItem = false;
	public bool isStackable = false;
	public bool isDestroyedOnUse = false;
	public float encumbranceValue = 0;
}
