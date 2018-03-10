using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	Death deathmenu;
	bool isPaused;
	GameObject Pause; //Canvas used for pause

	void Start ()
	{
		isPaused = false;
		Pause = GameObject.FindWithTag ("Pause");
		Pause.GetComponent<Canvas> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {

			isPaused = !isPaused; //Inverts bool

			if (isPaused) {
				//Pauses all bodies
				Time.timeScale = 0;

				//Disables background movements
				for (int i = 0; i <= 2; i++)
					GameObject.FindGameObjectsWithTag ("BackgroundScene") [i].GetComponent<BackgroundScroll> ().enabled = false;

				//Displays pause menu
				Pause.GetComponent<Canvas> ().enabled = true;

				//Disables gravity/pull script
				GameObject.FindWithTag ("Druffy").GetComponent<gravity> ().enabled = false;

				//Stops music
				GameObject.FindWithTag("BGMusic").GetComponent<AudioSource>().Pause();
				
			} else {
				//Disables the pause menu
				Pause.GetComponent<Canvas> ().enabled = false;
				Time.timeScale = 1; //Resumes all bodies

				//Re-enables background movement
				for (int i = 0; i <= 2; i++)
					GameObject.FindGameObjectsWithTag ("BackgroundScene") [i].GetComponent<BackgroundScroll> ().enabled = true;

				//Enables use of gravity/pull script
				GameObject.FindWithTag ("Druffy").GetComponent<gravity> ().enabled = true;

				//Plays music
				GameObject.FindWithTag("BGMusic").GetComponent<AudioSource>().Play();
			}
		}
	}

	public void Resume(){
		Pause.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 1;

		for (int i = 0; i <= 2; i++)
			GameObject.FindGameObjectsWithTag ("BackgroundScene") [i].GetComponent<BackgroundScroll> ().enabled = true;

		GameObject.FindWithTag ("Druffy").GetComponent<gravity> ().enabled = true;

		GameObject.FindWithTag("BGMusic").GetComponent<AudioSource>().Play();
	}
}