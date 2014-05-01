using UnityEngine;
using System.Collections;

public class CharacterPortriat : MonoBehaviour {
	public Texture2D character_left;
	public Texture2D character_right;
	private int selectedPortriat;

	// Use this for initialization
	void Start () {
		selectedPortriat = GameManager.selectedChar;
		if (selectedPortriat == 1)
			this.renderer.material.mainTexture = character_left;
		else
			this.renderer.material.mainTexture = character_right;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
