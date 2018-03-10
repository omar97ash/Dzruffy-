using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

	Scene currentScene;
	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}
	void Start () {
		Loadinfo.loadallinfo ();
		Debug.Log ("Coins: " + Death.totals);
		Debug.Log ("HP: " + PlayerHealth.currenthp);
	}
}