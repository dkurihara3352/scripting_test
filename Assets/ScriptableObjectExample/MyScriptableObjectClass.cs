using UnityEngine;
using System.Collections;


[CreateAssetMenu(fileName = "Data", menuName = "Custom/Data",order = 1)]
public class MyScriptableObjectClass : ScriptableObject{

	public string objectName = "New Scriptable Object";
	public bool isColorRandom = false;
	public Color thisColor = Color.white;
	public Vector3[] spawnPoints;
//	public Vector3[] SpawnPoints{
//		get{
//			for(int i = 0; i < spawnPoints.Length; i++){
//				spawnPoints[i] = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
//			}
//			return spawnPoints;
//		}
//
//	}
}
