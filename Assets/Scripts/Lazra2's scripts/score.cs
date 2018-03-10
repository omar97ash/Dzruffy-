using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public static float elscore ;
	public Text txtRef;
    int elscoreint;
    // Use this for initialization
    void awake(){
		//txtRef = GetComponent<UnityEngine.UI.Text> ();
	}
	float elapsedTime=0;
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime>0.1) {
			
			elscore += .1f;
		    elscoreint = (int)elscore;
			txtRef.text = elscoreint.ToString();
			GameObject.FindWithTag("Points_Won").GetComponent<Text>().text = elscoreint.ToString();
			elapsedTime = 0;
		}
	}
	
}