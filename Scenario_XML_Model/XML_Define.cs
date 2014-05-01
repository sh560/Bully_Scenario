using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Level")]
public class LevelContainer{

	[XmlElement("Quest")]
	public Level[] Quests;

    [XmlAttribute("name")]
    public string name;
	//public List<Level> Levels = new List<Level>();

	public static LevelContainer Load(string path){
		var serializer = new XmlSerializer (typeof(LevelContainer));
		using (var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize (stream) as LevelContainer;
		}

	}	
}

public class Quest{
	[XmlAttribute("name")]
	public string name;

    [XmlElement("CorrectAnswer")]
    public int correctAnswer;

	[XmlElement("Dialogue")]
	public string dialogue;

    [XmlElement("Answer")]
    public Answer[] Answers;
}

public class Answer
{
    [XmlElement("Text")]
    public string text;

    [XmlElement("Description")]
    public string description;

}