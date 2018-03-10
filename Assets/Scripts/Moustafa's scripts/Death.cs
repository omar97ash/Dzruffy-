using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Death : MonoBehaviour {

	PlayerHealth PH;

	GameObject player;
	GameObject DeathScreen; //Canvas used for pause

	public float Loss_Percentage = 25;
	bool started = false;

	public static int totals;
	public static int total_score;

	void Start ()
	{
		DeathScreen = GameObject.FindWithTag ("DeathScreen");
		DeathScreen.GetComponent<Canvas> ().enabled = false;
		player = GameObject.FindWithTag ("Druffy");
		PH = player.GetComponent<PlayerHealth> ();
	}
		
	void Update()
	{
		if (PH.Dead()) {
			Captured();
		}
	}

	public void Captured() {
		GameObject.FindGameObjectsWithTag ("Pause") [1].GetComponent<PauseMenu> ().enabled = false;
		DeathScreen = GameObject.FindWithTag ("DeathScreen");
	
		//Pauses all bodies
		Time.timeScale = 0;

		//Disables background movements
		for (int i = 0; i <= 2; i++)
			GameObject.FindGameObjectsWithTag ("BackgroundScene") [i].GetComponent<BackgroundScroll> ().enabled = false;

		//Displays captured menu
		DeathScreen.GetComponent<Canvas> ().enabled = true;

		//Disables gravity/pull script
		GameObject.FindWithTag ("Druffy").GetComponent<gravity> ().enabled = false;

		//Displays score
		double float_score = score.elscore;
		int int_score = (int)float_score;
		GameObject.FindWithTag ("Points_Won").GetComponent<Text> ().text = int_score.ToString ();

		int lost_score = int_score - (int)(int_score * (1 - (Loss_Percentage / 100)));
		GameObject.FindWithTag ("Points_Lost").GetComponent<Text> ().text = ("-" + lost_score.ToString ());

		total_score = int_score - lost_score;
		totals = total_score;

		GameObject.FindWithTag ("Total_Points").GetComponent<Text> ().text = ("+" + total_score.ToString ());

		//Stops music
		GameObject.FindWithTag ("BGMusic").GetComponent<AudioSource> ().Pause ();
	}


	//Bugged
	public void Restart(){
		PH.CurrentHealth = 1;
		GameObject.FindGameObjectsWithTag ("Pause")[1].GetComponent<PauseMenu> ().enabled = true;
		this.enabled = false;
		SceneManager.LoadScene(2);
		Time.timeScale = 1;
		Debug.Log ("timescale enabled");
		for (int i = 0; i <= 2; i++)
			GameObject.FindGameObjectsWithTag ("BackgroundScene") [i].GetComponent<BackgroundScroll> ().enabled = false;

		GameObject.FindWithTag ("Druffy").GetComponent<gravity> ().enabled = true;

		saveinfo.saveallinfo ();
	}
}