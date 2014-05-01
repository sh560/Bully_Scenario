using UnityEngine;
using System.Collections;

public class QuestSelect : MonoBehaviour {
	[System.NonSerialized]
	public bool Selected = false;
	//public GameObject Questions;
	public int LevelToLoad = 1;
	public int QuestID = -1;

	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents 

	// Use this for initialization
	void Start () {
		Selected = false;
		GameManager.QuestFlag = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		if (GameManager.QuestFlag == 0 && !(GameManager.isCompleted(QuestID))) {
			Selected = true;
			GameManager.QuestFlag = 1;
		}
	}

	void OnGUI () {
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix

		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

		GUIStyle BoxStyle = new GUIStyle ("Box");
		BoxStyle.fontSize = 24;
		BoxStyle.wordWrap = true;
		GUIStyle ButtonStyle = new GUIStyle("Button");
		ButtonStyle.fontSize = 24;
		ButtonStyle.wordWrap = true;


		if (GUI.Button(new Rect(20, 708, 50,50), "Home", ButtonStyle)) {
			GameManager.CurrentLocation = GameManager.LoadStart;
			Application.LoadLevel(GameManager.LoadStart);
		}

		if (GUI.Button(new Rect(90, 708, 50,50), "Map", ButtonStyle)) {
			GameManager.CurrentLocation = GameManager.LoadMap;
			Application.LoadLevel(GameManager.LoadMap);
		}

		if (GUI.Button(new Rect(160, 708, 50,50), "Help", ButtonStyle)) {
			//Application.LoadLevel(GameManager.LoadMap);
		}


		if (Selected && GameManager.QuestFlag == 1 && !GameManager.isCompleted(this.QuestID)) {
			GUI.Box(new Rect(0, 600, 1024,168), "This is the quest information after clicking on the quest.", BoxStyle);

			if (GUI.Button (new Rect(400,708,100,50), "Accept", ButtonStyle)) {
				GameManager.QuestFlag = 2;
				GameManager.CurrentQuest = QuestID;
				Selected = false;
				Application.LoadLevel(LevelToLoad);
			}

			if (GUI.Button (new Rect(580,708,100,50), "Return", ButtonStyle)){
				Selected = false;
				GameManager.QuestFlag = 0;
			}
		}

		GUI.matrix = svMat; // restore matrix
	}
}
