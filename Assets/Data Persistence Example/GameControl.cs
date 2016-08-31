using UnityEngine;
using System.Collections;
//these three namespaces pertains to Saving and Loading
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameControl : MonoBehaviour {

	public static GameControl Instance;
	void Awake(){
		if(Instance != null && Instance != this){
			Destroy(this);
			Debug.Log("GameControl instance is destroyed");
		}else{
			DontDestroyOnLoad(this);
			Instance = this;
			Debug.Log("GameControl instance is assigned");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Rect areaRect;
	public int health;
	public int level;

	string[] toolbarStrings = new string[3]{"Slot 0","Slot 1", "Slot 2"};
	int slotIndex = 0;

	void OnGUI(){
		GUILayout.BeginArea(areaRect);
		GUILayout.BeginVertical();
		GUILayout.Label("Health : " + health);
		GUILayout.Label("Level : " + level);
			if(GUILayout.Button("Health Up")){
			health += 10;
			}
			if(GUILayout.Button("Health Down")){
				health -= 10;
			}
			if(GUILayout.Button("Level Up")){
				level += 5;
			}
			if(GUILayout.Button("Level Down")){
				level -= 5;
			}
		GUILayout.Space(10.0f);
			if(GUILayout.Button("Save")) Save();
			if(GUILayout.Button("Load")) Load();

		slotIndex = GUILayout.Toolbar(slotIndex,toolbarStrings);

		GUILayout.EndVertical();
		GUILayout.EndArea();
	}

	string myPath;//defined in Awake
	public void Save(){

//		BinaryFormatter bf = new BinaryFormatter();
//		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
//		PlayerData data = new PlayerData(health, level);
//		bf.Serialize(file, data);
//		file.Close();
		switch(slotIndex){
		case 0: myPath = Application.persistentDataPath + "/playerInfo_0.dat"; break;
		case 1: myPath = Application.persistentDataPath + "/playerInfo_1.dat"; break;
		case 2: myPath = Application.persistentDataPath + "/playerInfo_2.dat"; break;
		}

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file;
		if(File.Exists(myPath))
			file = File.Open(myPath, FileMode.Open);
		else
			file = File.Create(myPath);
		PlayerData data = new PlayerData(health, level);
		bf.Serialize(file, data);
		file.Close();
	}

	public void Load(){

		switch(slotIndex){
		case 0: myPath = Application.persistentDataPath + "/playerInfo_0.dat"; break;
		case 1: myPath = Application.persistentDataPath + "/playerInfo_1.dat"; break;
		case 2: myPath = Application.persistentDataPath + "/playerInfo_2.dat"; break;
		}

		if(File.Exists(myPath)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(myPath, FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			health = data.health;
			level = data.level;
			file.Close();
		}
		else{
			Debug.Log("There's no such file :" + myPath);
		}

	}
}
