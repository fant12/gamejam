using UnityEngine;
using System.Collections;

public class Taschenlampe : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.L))
			light.enabled = !light.enabled;
	}
}