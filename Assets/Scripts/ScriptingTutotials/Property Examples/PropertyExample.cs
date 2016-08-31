using UnityEngine;
using System.Collections;

public class PropertyExample{

	private int experience = 87493;



	public int Experience{
		get{
			return experience;
		}
		set{
			experience = value;
		}
	}

	public int Level{
		get{
			return experience /2000 - experience %2000/experience;	
		}
		set{
			experience = value *2000;
		}
	}
}
