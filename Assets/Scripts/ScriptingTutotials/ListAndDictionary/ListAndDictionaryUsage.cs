using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ListAndDictionaryUsage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UseDictionary();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UseList(){
		List<BadGuy> badguys = new List<BadGuy>();
		badguys.Add(new BadGuy("Harvey", 50));
		badguys.Add(new BadGuy("Magneto", 100));
		badguys.Add(new BadGuy("Pip", 5));

		badguys.Sort();

		for(int i = 0; i < badguys.Count; i++){
			Debug.Log(badguys[i].name + " " + badguys[i].power);
		}
		badguys.Clear();
	}

	void UseDictionary(){
		Dictionary<string, BadGuy> badguys = new Dictionary<string, BadGuy>();

		badguys.Add("gangster", new BadGuy("Harvey", 50));
		badguys.Add("mutant", new BadGuy("Magneto", 100));

		Debug.Log(badguys["mutant"].name + " is a mutant");
		Debug.Log(badguys["gangster"].name + " is a gangster");
	}
}
