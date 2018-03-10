using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour {
	public int AttackDamage;
	public float startHP; 	//The initial value of enemy's health.

	GameObject player;
	GameObject shield; //for Graviton Charge Particle System
	GameObject UFO;

	PlayerHealth PH;

	private float HP;		//Refers to startHP
	private bool gShield = true;
	private float max;		//Used for particle system shield

	bool Crashed=false;
	bool started = false;

	[Header ("UI")]
	public Image healthBar;

	// Use this for initialization
	void Start () {
		if (!started) {
			player = GameObject.FindGameObjectsWithTag ("Druffy") [0];	//Assigns Druffy to variable player
			PH = player.GetComponent<PlayerHealth> ();					//For player health

			UFO = GameObject.FindWithTag ("UFO");

			shield = GameObject.FindWithTag ("GravCharge");				//Assigns Druffy's Graviton Shield to shield variable

			if (healthBar) {
				HP = startHP;
				//Debug.Log (this.gameObject + " HP set to " + startHP);
			}
		}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject == player) {
			Crashed = true;
			HP -= (player.GetComponent<Rigidbody2D> ().mass - player.GetComponent<Rigidbody2D> ().velocity.x);		//Reduces the object by the player's mass
			/*Debug.Log((player.GetComponent<Rigidbody2D> ().mass - player.GetComponent<Rigidbody2D> ().velocity.x)
				+ " damage done to " + this.gameObject + ". Enemy's health now is " + HP);*/

			//Druffy's Shield
			ParticleSystem.EmissionModule em = shield.GetComponent<ParticleSystem> ().emission; //Initializes emission module into variable 'em'
			max = em.rateOverTime.constantMax;	//Returns current max particles
			max--;										//Reduces particles
			max = (max <= 0) ? 0 : max;					//if max <= 0, set max to 0, else, do nothing.
			em.rateOverTime = Random.Range (0, max);	//Sets new particles
			Crash();

			//Checks to see if a healthBar is assigned to an enemy or not.
			if (healthBar)
			{
				healthBar.GetComponent<Image>().fillAmount = HP / startHP;	//Sets the percentage value
			}

			//If enemy's healthBar and HP reach 0, do the following.
			if (healthBar && HP <= 0)
			{
				Destroy (this.gameObject); //Destroys the instantiated prefab.
				score.elscore += this.gameObject.GetComponent<Rigidbody2D>().mass * 1.25f; //Adds to the score
				//Debug.Log (this.gameObject.GetComponent<Rigidbody2D> ().mass + " points added to score.");
			}
		}
	}

	void Crash(){
		//Takes damage if Shield is down.
		if (shield.GetComponent<ParticleSystem> ().emission.rateOverTime.constantMax == 0) {
			if (PH.CurrentHealth > 0) {
				PH.TakeDamage (AttackDamage);
				Crashed = false;
			}
		} 
	}
}
