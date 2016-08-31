using UnityEngine;
using System.Collections;
using System;

//The class needs to be clean (not inheriting MonoBehavior or such) to be serialized correctly
[Serializable]
public class PlayerData{

	public int health;
	public int level;

	public PlayerData(int healthParam, int levelParam){
		health = healthParam;
		level = levelParam;
	}
}
