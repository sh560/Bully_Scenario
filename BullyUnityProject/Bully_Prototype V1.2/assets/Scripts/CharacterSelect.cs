using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	public Texture2D character_left;
	public Texture2D character_right;
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	public int LevelToLoad = 1;
	
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

		GUI.depth = 1;
		//GUI.Box (new Rect (60, 110,400,600), "");
		//GUI.Box (new Rect (550, 110,400,600), );
		
		if (GUI.Button (new Rect (150,110,310,600), character_left)) {
			GameManager.selectedChar = 1;
			GameManager.mentor = character_left;
			Application.LoadLevel(LevelToLoad);
		}	
		if (GUI.Button (new Rect (550,110,310,600), character_right)) {
			GameManager.selectedChar = 2;
			GameManager.mentor = character_right;
			Application.LoadLevel(LevelToLoad);
		}
		
		GUI.matrix = svMat; // restore matrix
	}
}
