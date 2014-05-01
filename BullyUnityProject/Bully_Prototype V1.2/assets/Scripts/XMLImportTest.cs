using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;

public class XMLImportTest : MonoBehaviour {
	public int QuestionID;
	public int NumAnswers;
	private string[] strAnswer;
	private string strQuestion;
	public string FileLocation;
	public string FileName;
	
	
	// Use this for initialization
	void Start () {
		FileLocation = Path.Combine(Application.dataPath, FileName);
		LoadXmlDoc();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void LoadXmlDoc () {
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.

	}
}
