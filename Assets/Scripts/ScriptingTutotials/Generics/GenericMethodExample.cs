using UnityEngine;
using System.Collections;

public class GenericMethodExample{

	public T GenericMethod<T>(T param){
		return param;
	}

	public T GenericMethodStruct<T>(T param) where T : struct {
		return param;
	}

	public T GenericMethodClass<T>(T param) where T : class{
		return param;
	}
}
