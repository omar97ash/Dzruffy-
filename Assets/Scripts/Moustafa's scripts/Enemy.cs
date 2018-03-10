using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	[Header ("Movement")]
	public float cx; //Velocity across x-axis

	[Header ("Stats")]
	public int Damage; 		//Damage done by gameObject 
	public float startHP; 	//HP of gameObject

	[Header ("UI")]
	public Image healthBar;

	/* ***************** *
	 * Private variables *
	 * ***************** */
	private float HP; 		//Refers back to startHP
	private bool gShield = true;

	GameObject player;
	GameObject shield;

	PlayerHealth PH;

	//Init
	void Start () {
		player = GameObject.FindGameObjectsWithTag ("Druffy") [0];
		PH = player.GetComponent<PlayerHealth> ();
		shield = GameObject.FindWithTag ("GravCharge");
		//Debug.Log ("Assigned " + GameObject.FindWithTag ("GravCharge"));
		gShield = shield.GetComponent<ParticleSystem> ().emission.enabled;

		if (healthBar) {
			HP = startHP;
			Debug.Log (this.gameObject + "'s HP set to " + startHP);
		}
	}
	
	//Called once per frame
	void Update () {
		//Movement
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (cx, 0); //Sets object's x-axis velocity
		if (gameObject.GetComponent<Rigidbody2D>().position.x <= -18f) //After reaching X point, destroy.
			Destroy (this.gameObject);


	}
}