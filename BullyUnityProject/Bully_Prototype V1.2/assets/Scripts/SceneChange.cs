using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
	public int LevelToLoad = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		GameManager.CurrentLocation = LevelToLoad;
		Application.LoadLevel(LevelToLoad);
	}
}
