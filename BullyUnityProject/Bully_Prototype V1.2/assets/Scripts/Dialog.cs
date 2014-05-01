using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
	private string theDialog;
	private string dialogHelper;
	private int otherHelper;
	public float textSpeed;
	private float trackTime;
	
	// Use this for initialization
	void Start () {
		otherHelper = 0;
		theDialog = "This is the dialog that will be appearing. The text will show up here for the question and any dialog that is needed. Possibly some animation in the future.";
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI () {
		//Only use one of the two labels
		GUILayout.Label (dialogHelper); //For scrolling text
		//GUILayout.Label (theDialog); //Text is already there


		dialogHelper = theDialog.Substring(0, otherHelper);
		//Another way to disable the scrolling text, set text speed to < 0
		if (textSpeed < 0) {
			dialogHelper = theDialog;
		} else if (otherHelper < theDialog.Length && textSpeed < trackTime) { //Get the next part of the string to add
			otherHelper++;
			trackTime = 0f;
			for (int i = otherHelper; i < theDialog.Length; i++)
			{
				dialogHelper += " ";
			}
		}
		trackTime += Time.deltaTime;
	}
}
