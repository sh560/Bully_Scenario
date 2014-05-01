using UnityEngine;
using System.Collections;

public class GrayOut : MonoBehaviour {
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	public int GUIDepth = 3;


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
		GUI.backgroundColor = Color.black;
		GUI.Box (new Rect (0,0,1024,768), "");

		GUI.matrix = svMat; // restore matrix
	}
}
