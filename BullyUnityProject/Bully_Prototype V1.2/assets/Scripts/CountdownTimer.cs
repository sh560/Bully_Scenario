using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {
	private float timeLeft = 45.0f;
	public int GameOverNumber = 5;

	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents 
	private string TimeLeft;

	public void Start () {
	}

	public void Update()
	{
	  if(Questions.QuestProgress == 1){
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0.0f)
			{
				// End the level here.
				//guiText.text = "You ran out of time";
				waitfor (5);
				GameManager.CurrentQuest = -1;
				GameManager.QuestFlag = 0;
				Questions.QuestProgress = 0;
				Application.LoadLevel (GameOverNumber);
			}
			else
			{
				//guiText.text = "Time left = " + (int)timeLeft + " seconds";
				TimeLeft = "Time left = " + (int)timeLeft + " seconds";
			}
		}
	}

	void OnGUI(){
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

		GUIStyle QuestStyle = new GUIStyle ("Box");
		QuestStyle.fontSize = 24;

		if (Questions.QuestProgress == 1)
			GUI.Box (new Rect (574, 0, 300, 40), TimeLeft, QuestStyle);

		GUI.matrix = svMat; // restore matrix
	}

	public IEnumerator waitfor(int sec){
		yield return new WaitForSeconds (sec);
	}
}
