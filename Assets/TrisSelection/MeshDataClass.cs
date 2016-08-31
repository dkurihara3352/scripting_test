using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[CreateAssetMenu(fileName = "MeshData", menuName = "Custom/MeshData", order = 3)]
[System.Serializable]
public class MeshDataClass : MonoBehaviour{

	public string objectName = "New Mesh Data Name";
	public Transform trans;
	public CoupledTri[] coupledTris;
	public int zonesSize;
	public int activeZoneIndex;
	public MeshZone activeZone;
	public List<MeshZone> meshZones;
	public bool isReady = false;
	public string[] toolBarStrings;
	public bool isConverted = false;



	//bool hasMesh = false;


	void Awake(){
		//meshZones = new List<MeshZone>();
		activeZone = null;
	}

	public void Convert(){
		if(trans.gameObject.GetComponent<MeshFilter>() == null) /*hasMesh = false*/ return;
		else{
			//hasMesh = true;
			objectName = trans.gameObject.name;
			Mesh mesh = trans.gameObject.GetComponent<MeshFilter>().sharedMesh;
			int[] tris = mesh.triangles;
			Vector3[] verts = mesh.vertices;
			coupledTris = new CoupledTri[mesh.triangles.Length/3];

			for(int i = 0; i < tris.Length; i += 3){
				Vector3 p0 = verts[tris[i + 0]];
				Vector3 p1 = verts[tris[i + 1]];
				Vector3 p2 = verts[tris[i + 2]];
				Vector3 centroid = new Vector3((p0.x + p1.x + p2.x)/3, (p0.y + p1.y + p2.y)/3, (p0.z + p1.z + p2.z)/3);
				Vector2 p0uv = mesh.uv[tris[i + 0]];
				Vector2 p1uv = mesh.uv[tris[i + 1]];
				Vector2 p2uv = mesh.uv[tris[i + 2]];

				Vector3 udir = Vector3.zero;
				Vector3 vdir = Vector3.zero;

				if(p0uv.x == p1uv.x)
					if(p0uv.y > p1uv.y) vdir = (p0 -p1).normalized;
					else if(p0uv.y < p1uv.y)vdir = (p1 - p0).normalized;
					else Debug.Log("vertices UV incorrectly set");
				else if (p0uv.y == p1uv.y)
					if(p0uv.x > p1uv.x) udir = (p0 - p1).normalized;
					else if(p0uv.x < p1uv.x) udir = (p1 - p0).normalized;
					else Debug.Log("vertices UV incorrectly set");

				else if(p1uv.x == p2uv.x)
					if(p1uv.y > p2uv.y) vdir = (p1 -p2).normalized;
					else if(p1uv.y < p2uv.y)vdir = (p2 - p1).normalized;
					else Debug.Log("vertices UV incorrectly set");
				else if (p1uv.y == p2uv.y)
					if(p1uv.x > p2uv.x) udir = (p1 - p2).normalized;
					else if(p1uv.x < p2uv.x) udir = (p2 - p1).normalized;
					else Debug.Log("vertices UV incorrectly set");
	
				else if(p2uv.x == p0uv.x)
					if(p2uv.y > p0uv.y) vdir = (p2 -p0).normalized;
					else if(p2uv.y < p0uv.y)vdir = (p0 - p2).normalized;
					else Debug.Log("vertices UV incorrectly set");
				else if (p2uv.y == p0uv.y)
					if(p2uv.x > p0uv.x) udir = (p2 - p0).normalized;
					else if(p2uv.x < p0uv.x) udir = (p0 - p2).normalized;
					else Debug.Log("vertices UV incorrectly set");

				Vector3 normal = Vector3.Cross(vdir, udir);
				Vector3 tangent = (udir == Vector3.zero)? Vector3.Cross(normal, vdir): udir;
				Vector3 binormal = (vdir == Vector3.zero)? Vector3.Cross(udir, normal): vdir;

				CoupledTri newTri = new CoupledTri();
				newTri.triIndex = i/3;
				newTri.triName = "tri " + (i/3).ToString();
				newTri.p0 = trans.TransformPoint(p0);
				newTri.p1 = trans.TransformPoint(p1);
				newTri.p2 = trans.TransformPoint(p2);
				newTri.centroid = trans.TransformPoint(centroid);
				newTri.uDir = trans.TransformPoint(udir);
				newTri.vDir = trans.TransformPoint(vdir);
				newTri.normal = trans.TransformPoint(normal);
				newTri.tangent = trans.TransformPoint(tangent);
				newTri.binormal = trans.TransformPoint(binormal);

				coupledTris[i/3] = newTri;
				isConverted = true;
			}
		}
	}

	public void CreateZones(){
		meshZones = new List<MeshZone>();
		MeshZone.zonesSize = 0;
		toolBarStrings = new string[zonesSize];
		for(int i = 0; i <zonesSize; i++){
			MeshZone newMeshZone = new MeshZone();
			meshZones.Add(newMeshZone);
			toolBarStrings[i] = i.ToString();
		}


	}

	public void SetActiveZone(int index){
		if(meshZones.Count != 0){
			activeZone = meshZones[index];
			activeZoneIndex = index;
		}else return;
	}
}


