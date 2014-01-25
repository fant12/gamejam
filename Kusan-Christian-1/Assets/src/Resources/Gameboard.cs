using UnityEngine;
using System.Collections;

public class Gameboard : MonoBehaviour {

	private static Person _player;
	private static Vector3 start;
	private static Vector3 end;
	
	/**
	 * @brief Setzt den Spieler wieder auf eine Anfangsposition, wenn sein Angstlevel zu hoch angestiegen ist.
	 */ 
	public void GameOver(){
		
		if(_player.HasDied())
			this.transform.Translate(GenerateStartPoint());
	}
	
	/**
	 * @brief Generiert einen Startpunkt f&uuml;r den Spieler.
	 */ 
	private Vector3 GenerateStartPoint(){
		return new Vector3(Random.Range (0, this.renderer.bounds.size.x), 0, Random.Range(0, this.renderer.bounds.size.z));
	}
	
	/**
	 * @brief Bereitet ein neues Spiel vor.
	 */
	public void Start() {
		
		start = GenerateStartPoint();
		end = new Vector3(0, 0, 0);
		//_player = (Person) GameObject.Find("Protagonist");
		//_player.transform.Translate(start);
	}
	
	// Update is called once per frame
	public void FixedUpdate() {
		GameOver();
	}
	
	/**
	 * @brief Reagiert auf den h&ouml;chst unwahrscheinlichen Fall, dass der Spieler tats&auml;chlich gewinnen sollte.
	 */ 
	public void Victory(){
		
		Debug.Log("Sieg!");
	}
}