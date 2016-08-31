using UnityEngine;
using System.Collections;

public class trial : MonoBehaviour {

	public Transform trans;

	// Use this for initialization
	void Start () {
		Mesh mesh = trans.gameObject.GetComponent<MeshFilter>().sharedMesh;
		Debug.Log(mesh.vertices.Length);
		Debug.Log(mesh.uv.Length);
//		for(int i = 0; i < mesh.vertices.Length; i ++){
//			Debug.Log("vertex " + i + "'s local pos : " + mesh.vertices[i]);
//		}
		for(int i = 0; i < mesh.uv.Length; i++){
			Debug.Log("uv " + i + "'s reading : " + mesh.uv[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
