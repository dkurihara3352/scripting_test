using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeshDataManager {

	public MeshDataObject meshData;
	public string assetName;
	public int zonesToCreate;
	public int activeZoneIndex;
	public MeshZone activeZone;
	public bool isReady = false;
	public string[] toolBarStrings;
}