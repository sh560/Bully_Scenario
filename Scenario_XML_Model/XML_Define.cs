using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("LevelCollection")]
public class LevelContainer{

	[XmlElement("Level")]
	public Level[] Levels;

	//public List<Level> Levels = new List<Level>();

	public static LevelContainer Load(string path){
		var serializer = new XmlSerializer (typeof(LevelContainer));
		using (var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize (stream) as LevelContainer;
		}

	}	
}
public class Level{
	[XmlAttribute("name")]
	public string name;


	[XmlElement("Quest")]
	public Quest[] Quests;
}

public class Quest{
	[XmlAttribute("name")]
	public string name;

	[XmlElement("Dialogue")]
	public string dialogue;

	[XmlElement("NumAnswers")]
	public int numAnswers;

	[XmlElement("Answer")]
	public string[] Answers;
}