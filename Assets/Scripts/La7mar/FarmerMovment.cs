using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovment : MonoBehaviour {

	public float speed = 1f;
	public Vector2 fpos;

	// Update is called once per frame
	void Update () {
		fpos = transform.position;
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f); //Player moves across +ve x-axis
			gameObject.transform.rotation = new Quaternion (0, 0, 0, 0); //Player faces right direction
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= new Vector3 (speed * Time.deltaTime * (1.5f), 0.0f, 0.0f); //Player moves across -ve x-axis
			gameObject.transform.rotation = new Quaternion (0, -180, 0, 0); //Player faces left direction
		}

	}
}
