using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	static SceneSwitch Instance;
	Scene curScene;

	void Awake(){
		if(Instance != null && Instance != this){
			Destroy(this.gameObject);
		}else{
			DontDestroyOnLoad(this.gameObject);
			Instance = this;
		}
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public float buttonWidth = 100f;
	public float buttonHeight = 100f;
	string buttonText = "";
	[Range(.0f, 1.0f)]
	public float relativeYPos = .7f;
	int sceneToLoadIndex;

	void OnGUI(){
		curScene = SceneManager.GetActiveScene();
		switch(curScene.buildIndex){
			case 0: 
				buttonText = "To Scene 1"; 
				sceneToLoadIndex = 1;	
				break;
			case 1: 
				buttonText = "To Scene 0"; 
				sceneToLoadIndex = 0;
				break;
		}
		GUILayout.BeginArea(new Rect((Screen.width/2 - buttonWidth/2), Screen.height * relativeYPos, buttonWidth, buttonHeight));
		GUILayout.Label("Current Scene: " + curScene.buildIndex.ToString());
		if(GUILayout.Button(buttonText)){
			SceneManager.LoadScene(sceneToLoadIndex, LoadSceneMode.Single);
		}
		GUILayout.EndArea();

	}
}
