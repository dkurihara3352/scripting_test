using UnityEngine;
using System.Collections;

public class MyPlayer : MonoBehaviour {

	public int armour;
	public int damage;
	public GameObject gun;

	[SerializeField]
	public int Armour{
		get{return armour;}
		set{armour = value;}
	}

	public int Damage{
		get{return damage;}
		set{damage = value;}
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
