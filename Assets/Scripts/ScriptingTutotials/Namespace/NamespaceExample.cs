using UnityEngine;
using System.Collections;

namespace NamespaceExample{

	public class ClassAInNamespace{

		public string stringField;
		public void MemberMethodOfClassA(string printedLine){
			stringField = printedLine;
			Debug.Log(stringField);
		}
	}
		
}
