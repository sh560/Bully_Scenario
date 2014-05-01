using UnityEngine;
using System.Collections;

public class DialogHelper : MonoBehaviour {
	public GameObject gameObj;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.pixelOffset.Set (100, Screen.width);
	}
}
