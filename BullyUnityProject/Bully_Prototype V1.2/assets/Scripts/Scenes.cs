using UnityEngine;
using System.Collections;

public class Scenes {
	private Texture2D Background;
	private int NumberOfTransitions;
	public enum SceneType {Menu, Map, Quest, Question};
	private int NumberOfButtons;
	private int NumberOfBoxes;

	public void setBackground (Texture2D retVal) {
		Background = retVal;
	}

	public Texture2D getBackground () {
		return Background;
	}

	public void setNumberOfTransitions (int retVal) {
		NumberOfTransitions = retVal;
	}

	public int getNumberOfTransitions () {
		return NumberOfTransitions;
	}

	public void setNumberOfButtons (int retVal) {
		NumberOfButtons = retVal;
	}
	
	public int getNumberOfButtons () {
		return NumberOfButtons;
	}

	public void setNumberOfBoxes (int retVal) {
		NumberOfBoxes = retVal;
	}
	
	public int getNumberOfBoxes () {
		return NumberOfBoxes;
	}

	//TODO: Implement function to handle calling multiple transitions
	
}
