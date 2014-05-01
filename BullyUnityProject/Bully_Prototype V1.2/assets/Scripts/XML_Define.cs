using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Level")]
public class Level{
	
	[XmlElement("Quest")]
	public Quest[] Quests;
	
	[XmlAttribute("name")]
	public string name;
	//public List<Level> Levels = new List<Level>();
	
	public static Level Load(string path){
		var serializer = new XmlSerializer (typeof(Level));
		using (var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize (stream) as Level;
		}
		
	}	
}

public class Quest{
	[XmlAttribute("name")]
	public string name;
	
	[XmlElement("CorrectAnswer")]
	public int correctAnswer;

	[XmlElement("Question")]
	public string question;

	[XmlElement("Dialogue")]
	public string dialogue;

	[XmlElement("Advice")]
	public string advice;
	
	[XmlElement("Answer")]
	public Answer[] Answers;
}

public class Answer
{
	[XmlElement("Text")]
	public string text;
	
	[XmlElement("Description")]
	public string description;

	[XmlElement("Response")]
	public string[] Response;
	
}