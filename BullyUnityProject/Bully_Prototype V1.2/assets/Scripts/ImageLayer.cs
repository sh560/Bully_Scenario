using UnityEngine;
using System.Collections;

public class ImageLayer : MonoBehaviour {
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	public int GUIDepth = 1;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 3;
		var svMat = GUI.matrix; // save current matrix
		
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		GUI.depth = GUIDepth;
		GUIStyle BoxStyle = new GUIStyle ();
		BoxStyle.fontSize = 24;
		BoxStyle.wordWrap = true;

		GUIStyle NameStyle = new GUIStyle ("Box");
		NameStyle.fontSize = 24;
		NameStyle.wordWrap = true;


		GUI.Box(new Rect(50,75,370,593), GameManager.mentor);

		GUI.Box(new Rect(420, 75, 554,593), GameManager.Bio[GameManager.selectedChar-1], BoxStyle);
		
		GUI.matrix = svMat; // restore matrix
	}
}
