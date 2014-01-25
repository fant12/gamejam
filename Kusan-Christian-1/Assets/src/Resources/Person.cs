using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	public static int battery = 100;
	public static int distanceToDanger = 0;
	public static int levelOfFear = 0;
	public static float lossOfEnergy = 0.01f;
	public static int curIntenstiy = 100;
	
	private GameObject flashlight = null;
	private Light light = null;
	
	/**
	 * @brief Ver&auml;ndert den Batteriestand der Taschenlampe.
	 * @param int energy ist die Energie, die hinzu- oder abgezogen wird.
	 */
	public void ChangeBattery(int energy){
		battery += energy;
	}

	/**
	 * Pr&uuml;ft, ob der Spieler schon starb. 
	 */
	public bool HasDied(){
		return (100 <= levelOfFear);
	}
	
	public void OnCollisionEnter(Collision collision){
		
		switch(collision.gameObject.name){
			case "End": //((Gameboard) GameObject.Find("Gameboard")).Victory();
				break;
		}
	}

	/**
	 * @brief Reaktion auf ein Event.
	 * @param int delay definiert die Verz&ouml;gerung bis das Event auf den Charakter reagieren kann.
	 * @param int effect bestimmt wie stark das Event auf den Angstlevel des Charakters wirkt.
	 */ 
	public void ReactOn(int delay, int effect) {

		if(Time.time < delay)
			if(!light.enabled)
				levelOfFear += effect;
	}

	/**
	 * @brief Reaktion auf ein Event.
	 * @param int delay definiert die Verz&ouml;gerung bis das Event auf den Charakter reagieren kann.
	 * @param int effect bestimmt wie stark das Event auf den Angstlevel des Charakters wirkt.
	 * @param int energy ist die Energie die von der Batterie abgezogen wird.
	 */ 
	public void ReactOn(int delay, int effect, int energy){
		
		if(Time.time < delay)
			if(!light.enabled)
				levelOfFear += effect;
			else
				ChangeBattery(energy);
	}

	/**
	 * @brief Initialisierung.
	 */ 
	public void Start(){
		
		flashlight = GameObject.Find("Taschenlampe");
		if(null != flashlight){
			this.light.enabled = false;
			this.light.intensity = 0.76f;
			
			this.light.intensity -= Time.deltaTime * lossOfEnergy;
		}
	}

}