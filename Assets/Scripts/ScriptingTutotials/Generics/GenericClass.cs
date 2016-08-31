using UnityEngine;
using System.Collections;

public class GenericClass<T>{
	public T item;

	public void UpdateItem(T newItem){
		item = newItem;
	}
}
