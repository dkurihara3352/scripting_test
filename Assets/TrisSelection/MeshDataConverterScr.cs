using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeshDataConverterScr : MonoBehaviour {
	
	public Transform targetTrans;
	public MeshDataObject meshData;

	public string assetName;
	public bool showAllZoneTris = false;
	public bool showNTB = false;
	public int zonesToCreate;
	public bool isAssetNameValid = false;
	public bool showAlreadyUsedError = false;
	public bool showAllZones = false;
	public bool showActiveZoneTris = false;
	public bool showAZTrisOnScene = false;

	public int activeZoneIndex;
	public MeshZone activeZone;
	public bool isReady = false;
	public string[] toolBarStrings;



}
