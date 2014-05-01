using UnityEngine;
using System.Collections;

public class Scenarios {
	public enum Locations {Cafateria, Lake, Cabin, Field};
	private int Location;
	private Vector2 ScenarioPos;
	private string ScenarioDescription;
	private string[] ScenarioAnswers;
	private string[] ScenarioResponses;
	private string ScenarioLifeLine;
	private AudioClip ScenarioLifeLineAudio;
	private AudioClip[] ScenarioResponsesAudio;
	
	public int getLocation () {
		return Location;
	}
	
	public void setLocation (int value) {
		Location = value;
	}
	
	public Vector2 getScenarioPosition () {
		return ScenarioPos;
	}
	
	public void setScenarioPosition (Vector2 value) {
		ScenarioPos = value;
	}
	
	public void setScenarioPostion (float x, float y) {
		ScenarioPos = new Vector2(x,y);
	}
	
	public string getScenarioDescription () {
		return ScenarioDescription;
	}
	
	public void setScenarioDescription (string value) {
		ScenarioDescription = value;
	}
	
	public string[] getScenarioAnswers () {
		return ScenarioAnswers;
	}
	
	public void setScenarioAnswers (string[] Answers) {
		ScenarioAnswers = Answers;
	}
	
	public string[] getScenarioResponses () {
		return ScenarioResponses;
	}
	
	public void setScenarioResponses (string[] Responses) {
		ScenarioResponses = Responses;
	}
	
	public string getScenarioLifeLine () {
		return ScenarioLifeLine;
	}
	
	public void setScenarioLifeLine (string value) {
		ScenarioLifeLine = value;
	}
	
	public AudioClip getScenarioLifeLineAudio () {
		return ScenarioLifeLineAudio;
	}
	
	public void setScenarioLifeLineAudio (AudioClip audio) {
		ScenarioLifeLineAudio = audio;
	}
	
	public AudioClip[] getScenarioResponsesAudio () {
		return ScenarioResponsesAudio;
	}
	
	public void setScenarioResponsesAudio (AudioClip[] audio) {
		ScenarioResponsesAudio = audio;
	}
}
