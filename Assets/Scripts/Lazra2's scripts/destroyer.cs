using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float cx;
		cx = gameObject.GetComponent<Rigidbody2D> ().position.x;
		if (cx <= -18f) {
			Destroy (this.gameObject);
		}

	}
}

