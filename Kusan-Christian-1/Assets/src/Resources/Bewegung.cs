using UnityEngine;
using System.Collections;
using System;

public class Bewegung : MonoBehaviour {

	public int speed = 5;

	private int keyPressedV = 0;
	private int keyPressedH = 0;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void FixedUpdate () {keyPressedH = -Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow));
		keyPressedH += Convert.ToInt32(Input.GetKey(KeyCode.RightArrow));
		keyPressedV = Convert.ToInt32(Input.GetKey(KeyCode.UpArrow));
		keyPressedV += -Convert.ToInt32(Input.GetKey(KeyCode.DownArrow));

		Move();
	}
	
	private void Move(){
		SetCharacterOrientation();
		this.transform.Translate(speed * keyPressedH * Time.deltaTime, 0f, speed * keyPressedV * Time.deltaTime, Space.World);
	}

	private void SetCharacterOrientation(){
		
		Plane pl = new Plane(Vector3.zero, Vector3.up);
		float enter = 0;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//RaycastHit enter = new RaycastHit();
		pl.Raycast(ray, out enter);
		Vector3 vec3 = ray.GetPoint(enter);
		vec3.y = 0;

		Quaternion rotation = Quaternion.LookRotation(vec3 - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

		//transform.LookAt(vec3);*/
		//transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse Y"), 0) * 10);

		float horizontalMove = Input.GetAxisRaw("Horizontal");
		float verticalMove = Input.GetAxisRaw("Vertical");
		speed = (0 != horizontalMove && 0 != verticalMove) ? 1 : 3;
		
		transform.Translate(transform.right * horizontalMove * Time.deltaTime * speed);
		transform.Translate(transform.forward * verticalMove * Time.deltaTime * speed);
		
		Vector3 moveDirection= new Vector3(-verticalMove, 0, horizontalMove);  
		if(Vector3.zero != moveDirection){
			Quaternion rot = Quaternion.LookRotation(moveDirection);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 6 * Time.deltaTime);
		}
	}
		
	void OnGUI() {
		//Vector3 vec = Input.mousePosition;
		//GUI.Box (new Rect (0,0,300,25), vec.ToString());
	}
}
