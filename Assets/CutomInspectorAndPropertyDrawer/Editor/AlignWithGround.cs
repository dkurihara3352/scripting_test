using UnityEngine;
using System.Collections;
using UnityEditor;

public class AlignWithGround : MonoBehaviour {

	[MenuItem("Tools/Custom/Align with ground")]
	static void Align(){

		Transform[] transforms = Selection.transforms;
		for(int i =0; i< transforms.Length; i++){
			RaycastHit hit;
			if(Physics.Raycast(transforms[i].position, -Vector3.up, out hit)){
				Vector3 targetPosition = hit.point;
				if(transforms[i].gameObject.GetComponent<MeshFilter>() != null){
					Bounds bounds = transforms[i].gameObject.GetComponent<MeshFilter>().sharedMesh.bounds;
					targetPosition.y += bounds.extents.y;
				}
				transforms[i].position = targetPosition;
				Vector3 targetRotation = new Vector3(hit.normal.x, transforms[i].eulerAngles.y, hit.normal.z);
				transforms[i].eulerAngles = targetRotation;
			}

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
