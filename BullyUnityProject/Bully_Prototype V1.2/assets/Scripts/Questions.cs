using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {
	private Vector3 scale;
	public float originalWidth = 1024.0f;  // define here the original resolution
	public float originalHeight = 768.0f; // you used to create the GUI contents
	//Flag for quest states
	// 0: Quest hasn't started
	// 1: Quest started, timer is running
	// 2: Quest started, timer paused
	// 3: Quest Lifeline, timer paused
	// 4: End
	public static int QuestProgress;
	private string theDialog;
	private int answerNumber;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		QuestProgress = 0;
		answerNumber = -1;
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = GameManager.Narration[GameManager.CurrentQuest];
		audioSource.Play();
		Debug.Log(audioSource.volume);
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


		GUIStyle DialogStyle = new GUIStyle ("Label");
		DialogStyle.fontSize = 26;
		
		GUIStyle QuestStyle = new GUIStyle ("Button");
		QuestStyle.fontSize = 24;
		QuestStyle.wordWrap = true;

		GUI.Label (new Rect (0, 50, 1024,768), theDialog, DialogStyle);

		switch(QuestProgress) {
		case 0: //Read info
			GetDialog();

			if (GUI.Button (new Rect (462, 630, 100, 50), "Start", QuestStyle)) {
				QuestProgress = 1;
			}
			break;
		case 1: //Quiz time
			GetDialog();

			if (GUI.Button (new Rect (12, 550, 436, 95), GameManager.GetAnswer(1), QuestStyle)) {
				answerNumber = 1;
				PlayResponse(1);
				QuestProgress = 4;
			}
			if (GUI.Button (new Rect (576, 550, 436, 95), GameManager.GetAnswer(2), QuestStyle)) {
				answerNumber = 2;
				PlayResponse(2);
				QuestProgress = 4;
			}
			if (GUI.Button (new Rect (12, 660, 436, 95), GameManager.GetAnswer(3), QuestStyle)) {
				answerNumber = 3;
				PlayResponse(3);
				QuestProgress = 4;
			}
			if (GUI.Button (new Rect (576, 660, 436, 95), GameManager.GetAnswer(4), QuestStyle)) {
				answerNumber = 4;
				PlayResponse(4);
				QuestProgress = 4;
			}
			if (GUI.Button (new Rect (874, 0, 150, 40), "Pause", QuestStyle)) {
				QuestProgress = 2;
			}
			if (GUI.Button (new Rect (462, 630, 100, 50), "Advice", QuestStyle)) {
				QuestProgress = 3;
				audioSource.Stop ();
				audioSource.clip = GameManager.AudioLifeLine[GameManager.CurrentQuest][GameManager.selectedChar-1];
				audioSource.Play ();
			}
			break;
		case 2: //Pause
			if (GUI.Button (new Rect (462, 630, 100, 50), "Resume", QuestStyle)) {
				QuestProgress = 1;
			}
			break;
		case 3: //Lifeline
			theDialog = GameManager.GetLifeLine();

			if (GUI.Button (new Rect (462, 630, 100, 50), "Resume", QuestStyle)) {
				QuestProgress = 1;
				audioSource.Stop ();
			}
			break;
		case 4: //Answered question, load response

			theDialog = Answer(answerNumber);

			GUI.Box(new Rect(50,75,370,593), GameManager.mentor);

			if (GUI.Button (new Rect (24, 685, 400, 65), "Go Back")) {
				GameManager.QuestFlag = 0;
				GameManager.CurrentQuest = -1;
				Application.LoadLevel(GameManager.CurrentLocation);
			}

			break;
		default: //Catch any invalid numbers
			Debug.Log("Quest Progress Number invalid: " + QuestProgress);
			break;
		}

		GUI.matrix = svMat; // restore matrix
	}

	//Returns the response according to the answer given, accounting for which mentor is selected.
	private string Answer (int chosenAnswer) {
		if (GameManager.isCorrect(chosenAnswer)) {
			//Add points here
		}

		GameManager.CompleteQuest ();

		return GameManager.GetResponse (chosenAnswer);
	}

	private void GetDialog () {
		theDialog = GameManager.GetQuest();
	}

	private void PlayResponse (int chosenAnswer) {
		int temp = (chosenAnswer * 2) - 1;
		audioSource.Stop ();
		if (GameManager.selectedChar == 1) {
			audioSource.clip = GameManager.AudioResponse[GameManager.CurrentQuest][temp - 1];
		}
		else if (GameManager.selectedChar == 2) {
			audioSource.clip = GameManager.AudioResponse[GameManager.CurrentQuest][temp];
		}
		audioSource.Play ();
	}
}
