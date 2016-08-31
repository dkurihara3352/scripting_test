using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MeshDataObject : ScriptableObject {
	
	public string objectName = "New Mesh Data Name";
	public CoupledTri[] coupledTris;
	public List<MeshZone> meshZones;
	public List<MeshZoneList> zoneGroup;
	public bool isConverted = false;

}

[System.Serializable]
public class MeshZoneList{
	public List<MeshZone> childMeshZones;
}