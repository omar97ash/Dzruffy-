using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UFOpull : MonoBehaviour {

	private Rigidbody2D CurrentObject;
	public bool Attract = true;
	public Rigidbody2D TargetObject;
	public float velocity;

	void Start() {
		CurrentObject = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (Attract == true) {
			// Smoothly transforms TargetObject's position to the CurrentObject over a period of time.
			TargetObject.GetComponent<Rigidbody2D> ().transform.position = Vector2.Lerp (TargetObject.position, new Vector2((CurrentObject.position.x), (TargetObject.position.y)), velocity);
		}
	}
}
