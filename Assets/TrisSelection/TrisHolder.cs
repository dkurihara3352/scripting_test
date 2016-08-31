using UnityEngine;
using System.Collections;

public class TrisHolder : MonoBehaviour {


	public Transform targetMeshTransform;
	public CoupledTri myTri;
	public CoupledTri[] myTris;
	//public ReindexedMeshObject myObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

//[System.Serializable]
//public class CoupledTri{
//
//	public int triIndex;
//	public Vector3 p0;
//	public Vector3 p1;
//	public Vector3 p2;
//	public Vector3[] pArray;
//
//	public CoupledTri(int triID, Vector3 p0, Vector3 p1, Vector3 p2){
//		triIndex = triID;
//		this.p0 = p0;
//		this.p1 = p1;
//		this.p2 = p2;
//		pArray = new Vector3[3]{this.p0, this.p1, this.p2};
//	}
//}
//	
//[System.Serializable]
//public class ReindexedMeshObject{
//
//	public Transform trans;
//	public CoupledTri[] coupledTris;
//}
