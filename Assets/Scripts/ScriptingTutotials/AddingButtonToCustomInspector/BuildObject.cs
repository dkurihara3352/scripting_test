using UnityEngine;
using System.Collections;

public class BuildObject : MonoBehaviour {

	public GameObject obj;
	public Transform spawnTrans;

	public void InstantiateObject(){
		obj.GetComponent<Light>().color = new Color(Random.Range(.0f, 1f), Random.Range(.0f, 1f), Random.Range(.0f, 1f));
		Instantiate(obj, spawnTrans.position, Quaternion.identity);
	}

	void OnDrawGizmos(){
		if(spawnTrans != null){
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(spawnTrans.position, 1f);

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
