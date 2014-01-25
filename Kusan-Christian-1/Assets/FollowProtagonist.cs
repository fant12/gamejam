using UnityEngine;
using System.Collections;

public class FollowProtagonist : MonoBehaviour {

	private GameObject Protagonist;

	// Use this for initialization
	void Start () {
		Protagonist = GameObject.Find("Protagonist");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Protagonist.transform.position.x, 11.39278f, Protagonist.transform.position.z);
	}
}
