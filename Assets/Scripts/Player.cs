using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Camera camera;
	Rigidbody rb;
	public float walkSpeed;
	public float sensitivity;
	public float rotationX;
	public float rotationY;
	public float minimumY;
	public float maximumY;
	private Vector3 pos;

	void Start () {
		pos = transform.position;
		rb = GetComponent<Rigidbody>();	
		rb.freezeRotation = true;
	}
	
	void CameraControl(){
		rotationX = camera.transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivity;
		rotationY += Input.GetAxis ("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		camera.transform.localEulerAngles = (new Vector3(-rotationY, rotationX, 0));
		transform.localEulerAngles = (new Vector3(0, rotationX, 0));
	}

	void Movement(){
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		//transform.localPosition += (Movement * walkSpeed * Time.deltaTime);

		if(Movement.z < 0){
			Movement += transform.forward;
		} else if (Movement.z > 0){
			Movement -= transform.forward;
		}

		if(Movement.x < 0){
			Movement += transform.right;
		} else if (Movement.x > 0){
			Movement -= transform.right;
		}
		 transform.position = new Vector3 (0,0,0);
	}

	void HideAndLockMouse(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
		CameraControl();
		Movement();
		HideAndLockMouse();
	}
}
