using UnityEngine;
using System.Collections;

public class BullyDialog : MonoBehaviour {
	public Texture2D textureToChangeTo;
	private GUIStyle myGUIStyle;
	private bool triggered;
	private bool answered;
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents 
	
	// Use this for initialization
	void Start () {
		triggered = false;
		answered = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(triggered);
		Debug.Log(answered);
	}
	
	void OnTriggerEnter () {
		triggered = true;
	}
	
	void OnGuid () {
	//	if (triggered && !answered) {
			scale.x = Screen.width/originalWidth; // calculate hor scale
			scale.y = Screen.height/originalHeight; // calculate vert scale
			scale.z = 1;
			var svMat = GUI.matrix; // save current matrix
		
			// substitute matrix - only scale is altered from standard
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
			GUI.Box (new Rect (0, 0, 200, 200), "The question will go here");
			if (GUI.Button (new Rect (40, Screen.height-120, 380, 50), "The first answer")) {
				answered = true;
				changeText ();
			}
			if (GUI.Button (new Rect (430, Screen.height-120, 380, 50), "The second answer")) {
				answered = true;
				changeText ();
			}
			if (GUI.Button (new Rect (40, Screen.height-60, 380, 50), "The third answer")) {
				answered = true;
				changeText ();
			}
			if (GUI.Button (new Rect (430, Screen.height-60, 380, 50), "The fourth answer")) {
				answered = true;
				changeText ();
			}
	//	}
	}
	
	void changeText () {
		this.renderer.material.mainTexture = textureToChangeTo;
	}
}
