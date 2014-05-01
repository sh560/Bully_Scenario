using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	public int LevelToLoad = 1;
	public int GUIDepth = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix

		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

		GUI.depth = GUIDepth;

		GUIStyle menu = new GUIStyle("Button");
		menu.fontSize = 40;
		GUIStyle BlankStyle = new GUIStyle ();
		BlankStyle.fontSize = 100;
		BlankStyle.fontStyle = menu.fontStyle;
		BlankStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Box (new Rect (0, 0, 1024, 200), "The Title is here", BlankStyle);


		if (GUI.Button(new Rect (350, 200,350,100), "New Game", menu)) {
			Application.LoadLevel(LevelToLoad);
		}

		if (GUI.Button(new Rect (350, 350,350,100), "Continue", menu)) {
			//Application.LoadLevel(LevelToLoad);
		}

		if (GUI.Button(new Rect (350, 500,350,100), "Options", menu)) {
			//Application.LoadLevel(LevelToLoad);
		}

		if (GUI.Button(new Rect (350, 650,350,100), "Help", menu)) {
			//Application.LoadLevel(LevelToLoad);
		}


		GUI.matrix = svMat; // restore matrix
	}
}
