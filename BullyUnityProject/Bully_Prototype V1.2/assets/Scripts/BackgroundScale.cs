using UnityEngine;
using System.Collections;

public class BackgroundScale : MonoBehaviour {
	private float height;
	private float width;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Screen.height);
		Debug.Log(Screen.width);

		height = Camera.main.orthographicSize * 2.0f;
		width = height / Screen.height * Screen.width;

	}
}
