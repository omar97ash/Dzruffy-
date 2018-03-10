using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float StartingHealth=100;
	public float CurrentHealth;
	public Slider HealthSlider;
	Death dead;
    GM gm;

	public static float currenthp;

	bool isDead;
	//bool damaged;


	// Use this for initialization
	void Awake () {
		CurrentHealth = StartingHealth;
        gm = GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update () {
		//damaged = false;
	}

	public void TakeDamage (int amount){
		//damaged = true;
		CurrentHealth -= amount;
		HealthSlider.value = (CurrentHealth / StartingHealth) * 100;
		Debug.Log ("Druffy's health now is " + CurrentHealth);
		currenthp = CurrentHealth;
		if (CurrentHealth <= 0 && !isDead) {
			Dead ();
            if (gm != null)
            {
                gm.lastScore += (int)score.elscore;
                PlayerPrefs.SetInt("LastScore", gm.lastScore);
            }
        }
	}

	public bool Dead(bool dead = false){
		if (CurrentHealth <= 0) {
			dead = true;
			return dead;
		} else {
			dead = false;
			return dead;
		}
	}
}
