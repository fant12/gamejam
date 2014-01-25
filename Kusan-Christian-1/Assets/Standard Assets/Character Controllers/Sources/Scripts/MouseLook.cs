using UnityEngine;
using System.Collections;


/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character 
/// already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { 
		MouseXAndY = 0, 
		MouseX = 1, 
		MouseY = 2 
	};
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public float minimumX = -360f;
	public float maximumX = 360f;

	public float minimumY = -60f;
	public float maximumY = 60f;

	float rotationY = 0;

	void Update(){

		if(axes == RotationAxes.MouseXAndY){

			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if(axes == RotationAxes.MouseX)
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start (){
		// Make the rigid body not change rotation
		//if (rigidbody)
		//	rigidbody.freezeRotation = true;
	}
}