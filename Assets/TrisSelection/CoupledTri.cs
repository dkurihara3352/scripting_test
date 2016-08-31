using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CoupledTri{
	public string triName;
	public int triIndex;

	public Vector3 p0;
	public Vector3 p1;
	public Vector3 p2;
	public Vector3 centroid;

	public Vector3 normal;
	public Vector3 tangent;
	public Vector3 binormal;

	public Vector3 uDir;
	public Vector3 vDir;

	public Vector2 p0uv;
	public Vector2 p1uv;
	public Vector2 p2uv;

	public bool VertMatches(Vector3 vert){
		if(vert == p0 || vert == p1 || vert == p2) return true;
		else return false;
	}

}

[System.Serializable]
public class MeshZone{
	public static int zonesSize = 0;
	public int index;
	public string zoneName;
	public List<CoupledTri> zoneTris;
	public Color zoneColor;
	public bool showZoneTris = false;
	public bool showZone = false;


	public MeshZone(){
		index = zonesSize++;
		zoneTris = new List<CoupledTri>();
		zoneName = "Zone" + index.ToString();
		zoneColor = Color.HSVToRGB((zonesSize/10f)%1f, .7f, 1f);
		zoneColor.a *= .3f;
	}

	public bool IsAdjescentTo(MeshZone other){
		for(int i = 0; i < zoneTris.Count; i++){
			for(int j = 0; j < other.zoneTris.Count; j++){
				if(other.zoneTris[j].VertMatches(zoneTris[i].p0) ||
					other.zoneTris[j].VertMatches(zoneTris[i].p1) ||
					other.zoneTris[j].VertMatches(zoneTris[i].p2))
					return true;
			}
		}
		return false;
	}
	~MeshZone(){
		Debug.Log("Mesh Zone is destroyed");
	}
}

