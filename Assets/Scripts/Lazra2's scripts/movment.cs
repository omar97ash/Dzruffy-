using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour {
	public float cx;
	public float cy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (cx, cy);
		if(cx<-18f){
			Destroy (gameObject);
		}
	}
}
