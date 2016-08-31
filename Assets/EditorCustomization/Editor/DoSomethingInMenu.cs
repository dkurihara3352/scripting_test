using UnityEngine;
using UnityEditor;

public class DoSomethingInMenu{

	[MenuItem("Custom/Some Menu Action")]
	static void SomeMenuAction(){
		string menuPath = "Custom/Some Menu Action";
		bool toggle = Menu.GetChecked(menuPath);
		Menu.SetChecked(menuPath, !toggle);

		Debug.Log(toggle?"Off":"On");
	}

#region ContextMenu
//Transform にメニューを追加
//	[MenuItem("CONTEXT/Transform/Example1")]
//	static void Example1 () { }
//
//	//コンポーネント（すべて）にメニューを追加
//	[MenuItem("CONTEXT/Component/Example2")]
//	static void Example2 () { }
//
//	//ExampleScript（スクリプト）にメニューを追加
//	[MenuItem("CONTEXT/ExampleScript/Example3")]
//	static void Example3 () { }
#endregion

	#region Accessing Component from Context menu
//[MenuItem("CONTEXT/Transform/Example1")]
//	static void Example1 (MenuCommand menuCommand)
//	{
//		//実行した Transform の情報が取得できる
//		Debug.Log (menuCommand.context);
//	}
#endregion
}
