using UnityEngine;
using System.Collections;

public class MentorBio : MonoBehaviour {
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	public int GUIDepth = 2;
	public AudioClip Daniel;
	public AudioClip Joy;

	// Use this for initialization
	void Start () {
		this.audio.volume = 0.05f;
		if (GameManager.selectedChar == 1) {
			this.audio.clip = Daniel;
			this.audio.Play();
		} 
		else if (GameManager.selectedChar == 2) {
			this.audio.clip = Joy;
			this.audio.Play();
		}
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

		GUIStyle BlankStyle = new GUIStyle ();
		GUIStyle BoxStyle = new GUIStyle ("Box");
		BoxStyle.fontSize = 24;
		BoxStyle.wordWrap = true;
		GUIStyle ButtonStyle = new GUIStyle("Button");
		ButtonStyle.fontSize = 24;
		ButtonStyle.wordWrap = true;



		GUI.Box(new Rect(50, 75, 924,593), "",BoxStyle);
		//GUI.Box(new Rect(80, 75, 864,593), BoxStyle);

		if (GUI.Button(new Rect(new Rect (324, 685, 200, 65)), "Go Back", ButtonStyle)) {
			Application.LoadLevel(Application.loadedLevel - 1);
		}

		if (GUI.Button(new Rect(new Rect (700, 685, 200, 65)), "Confirm Mentor", ButtonStyle)) {
			Application.LoadLevel(GameManager.LoadMap);
		}

		GUI.matrix = svMat; // restore matrix
	}
}
