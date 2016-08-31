using UnityEngine;


public enum IngredientUnits{Spoon, Cup, Bowl, Piece}

[System.Serializable]
public class Ingredient{

	public string name;
	public int amount;
	public IngredientUnits unit;
}

public class IngredientTester: MonoBehaviour{

	public Ingredient resultedPotion;
	public Ingredient[] potionIngredients;


	void Start(){
		
	}

	void Update(){
		
	}

}
