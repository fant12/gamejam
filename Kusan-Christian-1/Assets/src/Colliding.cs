using UnityEngine;
using System.Collections;

public class Colliding : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision) {
		Translator.main.deleteBall(collision.gameObject);
        //DestroyObject(collision.gameObject);
    }
	
}