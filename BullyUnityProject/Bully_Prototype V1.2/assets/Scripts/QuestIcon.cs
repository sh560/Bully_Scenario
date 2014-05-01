using UnityEngine;
using System.Collections;

public class QuestIcon : MonoBehaviour {
	public Texture2D Available;
	public Texture2D Locked;
	public Texture2D Completed;
	public Texture2D Incorrect;

	private int QuestID;

	// Use this for initialization
	void Start () {
		QuestID = transform.parent.gameObject.GetComponent<QuestSelect>().QuestID;
	}
	
	// Update is called once per frame
	void Update () {
		switch (QuestID) {
		case 0:
			if (GameManager.isCompleted(QuestID)) {
				this.renderer.material.mainTexture = Completed;
			}
			break;
		case 1:
			if (GameManager.isCompleted(QuestID)) {
				this.renderer.material.mainTexture = Completed;
			}
			else if (GameManager.isCompleted(0)) {
				this.renderer.material.mainTexture = Available;
			}else {
				//this.renderer.material.mainTexture = Locked;
			}
			break;
		case 2:
			if (GameManager.isCompleted(QuestID)) {
				this.renderer.material.mainTexture = Completed;
			}
			else if (GameManager.isCompleted(0) && GameManager.isCompleted(1)) {
				this.renderer.material.mainTexture = Available;
			}else {
				//this.renderer.material.mainTexture = Locked;
			}
			break;
		}
	}
}
