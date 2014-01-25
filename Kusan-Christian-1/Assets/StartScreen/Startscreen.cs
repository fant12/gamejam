using UnityEngine;
using System.Collections;

public class Startscreen : MonoBehaviour {
	public int buttonWidth = 80;
	public int buttonHeight = 25;
	private float time = 0;
	private bool bTimer = true;

	void OnGUI() {
		if (bTimer) {
			time += Time.deltaTime;
			if (time > 5)
				bTimer = false;
		} else {
			if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2-(buttonHeight+2),buttonWidth,buttonHeight), "Start Game"))
				Application.LoadLevel(2);
			if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2,buttonWidth,buttonHeight), "Credits"))
				Application.LoadLevel(1);
			if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2+(buttonHeight+2),buttonWidth,buttonHeight), "Exit Game"))
				Application.Quit();
		}
	}
}
