using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Levels_Load : MonoBehaviour {
	// Use this for initialization
	public string xmlPath;
	//public LevelContainer levelDoc;
	public Level[] levels;
	public string Level1Quests;

	void Start () {
		xmlPath = Path.Combine (Application.dataPath, "xmlData.xml");
		//levelDoc = LevelContainer.Load(xmlPath);

		//levels = levelDoc.Levels;

		foreach (Level level in levels) {
			Debug.Log (level.name);
			foreach(Quest quest in level.Quests){
				Debug.Log (quest.name);
				Debug.Log (quest.dialogue);
				for(int i = 0; i < quest.Answers.Length; i++){
					Debug.Log (quest.Answers[i]);
				}
			}
		}
	}
	void OnGUI(){
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), (levels[0].name + "\n\t" + 
		                                                          	levels[0].Quests[0].name + "\n\t\t" +
		                                                          		levels[0].Quests[0].dialogue + "\n\t" +
		                                                          	levels[0].Quests[1].name + "\n\t\t" +
		                                                         		 levels[0].Quests[1].dialogue));
	}
	// Update is called once per frame
	void Update () {
	
	}
}
