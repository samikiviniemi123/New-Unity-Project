using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;

	Rigidbody rb;

	private Camera mainCamera;

	public GunController theGun;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
	}
	

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		if (groundPlane.Raycast (cameraRay, out rayLength)) {
			Vector3 pointToLook = cameraRay.GetPoint (rayLength);

			transform.LookAt (new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}
		if (Input.GetMouseButtonDown (0)) {
			theGun.isFiring = true;
		}
			if (Input.GetMouseButtonUp (0)) {
				theGun.isFiring = false;
			}
	}
}
