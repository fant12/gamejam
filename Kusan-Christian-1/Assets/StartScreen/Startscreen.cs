using UnityEngine;
using System.Collections;

public class Startscreen : MonoBehaviour {
	public int buttonWidth = 80;
	public int buttonHeight = 25;
	private float time = 0;
	private bool bTimer = true;

	private bool showCredits = false;
	private Vector3 up = new Vector3(0,0.08f,0);
	private Vector3 guiStart;
	public GUIText oGuiText;
	private string sGuiText = "Dark Alley\n" + "\n\n" +
		"Global Game Jam - Leipzig (Germany)\n" + "\n\n" +
		"Team\n" + "\n" +
		"Patrick Schmidt - Spielidee, Sounds, Programmierung\n" +
		"Christopher Helmbold - Leveldesign, Programmierung\n" +		
		"Stefan Erhardt - 3D, Grafiken, Interface\n" +
		"Christian Kusan - Programmierung, Spiellogik\n" + "\n\n" +
		"Special Thanks\n" + "\n" +
		"Daniel Ackermann - Leveldesign\n" + "\n\n" +
		"Graphics\n" + "\n" +
		"hdwallpaper-s.com - Night quarter\n" + "\n\n" +
		"Sounds\n" + "\n" +
		"freesfx.co.uk";
	
	void Start() {
		oGuiText.text = sGuiText;
		guiStart = oGuiText.transform.position;
	}

	void OnGUI() {
		if (bTimer) {
			time += Time.deltaTime;
			if (time > 5)
				bTimer = false;
			return;
		}

		if (showCredits)
			return;

		if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2-(buttonHeight+2),buttonWidth,buttonHeight), "Start Game"))
			Application.LoadLevel(2);
		if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2,buttonWidth,buttonHeight), "Credits"))
			showCredits = true;
		if (GUI.Button(new Rect(Screen.width/2-buttonWidth/2,Screen.height/2+(buttonHeight+2),buttonWidth,buttonHeight), "Exit Game"))
			Application.Quit();
	}
	
	void FixedUpdate() {
		if (showCredits) {
			oGuiText.transform.Translate(up * Time.deltaTime);
			if (oGuiText.transform.position.y > 1.5f || Input.GetMouseButtonDown(1)) {
				showCredits = false;
				oGuiText.transform.position = guiStart;
			}
		}
	}

}
