using UnityEngine;
using System.Collections;

public class Portraits : MonoBehaviour {
	public Texture2D character_left;
	public Texture2D character_right;
	private Texture2D left;
	public Texture2D right;
	private GUIStyle myGUIStyle;
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents 
	
	// Use this for initialization
	void Start () {
		myGUIStyle = new GUIStyle ();
		if (GameManager.selectedChar == 1)
			left = character_left;
		else
			left = character_right;
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
				
		GUI.Box (new Rect (0,475,100,100), left, myGUIStyle);
		GUI.Box (new Rect (924,475,100,100), right, myGUIStyle);
		
		GUI.matrix = svMat; // restore matrix
	}
}
