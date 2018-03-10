using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravity : MonoBehaviour {
	
	public Slider charge;
	public float drain_speed = 1.25f;
	public float recharge_speed = 1f;
	public float _gravity;
	public float range = 3.5f; //variable for pulling range.
	public Vector2 pos; //druffy position
	public GameObject farmerpos; //refering farmer position fom the FarmerMovment script
	public GameObject warning; // Warning text to notify the user that he's out of pulling range
	private FarmerMovment others; //Linking the 2 scripts together
	private Vector2 fpos2; //Variable to hold the value from the other script


	// Use this for initialization
	void Start () {
		others = farmerpos.GetComponent<FarmerMovment> ();
		fpos2 = others.fpos;
		_gravity = gameObject.GetComponent<Rigidbody2D> ().gravityScale;
		warning.GetComponent<Text> ().enabled = false;	//Out of Range text is disabled by default
	}

	// Update is called once per frame
	void Update () {
		pos = transform.position;

		others = farmerpos.GetComponent<FarmerMovment> ();
		fpos2 = others.fpos;

		gameObject.GetComponent<Rigidbody2D> ().gravityScale = _gravity;
	
	
		if (Input.GetButton ("Fire1") && (charge.GetComponent<Slider>().value > 0)){
			if (fpos2.x > pos.x - range && fpos2.x < pos.x + range) {
			
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = -(_gravity);
				charge.GetComponent<Slider> ().value -= drain_speed;

				if (charge.GetComponent<Slider> ().value == 0)
					gameObject.GetComponent<Rigidbody2D> ().gravityScale = (_gravity);
			} else
				StartCoroutine ("OutOfRange"); //To display Out of Range text
		}

		else charge.GetComponent<Slider> ().value += recharge_speed;

	}
	IEnumerator OutOfRange() //A loop(?)
	{
		warning.GetComponent<Text> ().enabled = true;				//Shows text
		if (fpos2.x > pos.x - range && fpos2.x < pos.x + range) {
			warning.GetComponent<Text> ().enabled = false;			//Hides text
		} else {
			yield return new WaitForSeconds (1);					//Waits for 1 second before hiding text
			warning.GetComponent<Text> ().enabled = false;
		}
	}
}
