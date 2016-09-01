using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeshDataConverterScr : MonoBehaviour {
	
	public Transform targetTrans;
	
	
	//Mesh Data Management
	public int numOfMeshData;
	public MeshDataManager[] meshDataManagers;
	public MeshDataManager activeMDM;
	public string[] MDMstrings;
	public int activeMDMIndex;


	//fields that should be stored individually
	// public MeshDataObject meshData;
	// public int zonesToCreate;
	// public int activeZoneIndex;
	// public MeshZone activeZone;
	// public bool isReady = false;
	// public string[] toolBarStrings;

	//vars about settings shared across all the Mesh Datas
	public string assetName;
	public bool showAllZoneTris = false;
	public bool showNTB = false;
	public bool isAssetNameValid = false;
	public bool showAlreadyUsedError = false;
	public bool showAllZones = false;
	public bool showActiveZoneTris = false;
	public bool showAZTrisOnScene = false;

}
