using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmerPull : MonoBehaviour {
	
	private Rigidbody2D CurrentObject;
//	public bool Attract;
//	public bool farmer;
//	public bool ufo;
	public Rigidbody2D TargetObject;
	public Rigidbody2D Opponent;
	public float velocity;

	void Start() {
		CurrentObject = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if ((Input.GetButton ("Fire1")) && (Opponent.GetComponent<UFOpull>().Attract = true)) {
				// Stops the opponent from attracting the TargetObject.
				Opponent.GetComponent<UFOpull> ().Attract = false;
				// Smoothly transforms TargetObject's position to the CurrentObject over a period of time.
				TargetObject.GetComponent<Rigidbody2D> ().transform.position = Vector2.Lerp (TargetObject.position, CurrentObject.position, velocity);
			}
		else
			Opponent.GetComponent<UFOpull> ().Attract = true; // When the Mouse0 button is released, the Opponent begins attracting TargetObject again.
	}
}