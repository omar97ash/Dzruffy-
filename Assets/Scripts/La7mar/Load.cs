using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadinfo {

	public static void loadallinfo() {
		
		Death.totals = PlayerPrefs.GetInt ("coins");
		PlayerHealth.currenthp = PlayerPrefs.GetFloat ("hp");

	}
		
}
