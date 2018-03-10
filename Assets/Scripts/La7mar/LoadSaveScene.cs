using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveScene : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Loadinfo.loadallinfo ();
		Debug.Log ("Coins: " + Death.totals);
		Debug.Log ("HP: " + PlayerHealth.currenthp);
	}


}
