using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    [HideInInspector]
    public int lastScore;

	// Use this for initialization
	void Start () {
        lastScore = GetLastScore();
        print("accumulativeScore:" + lastScore);
    }

    void OnApplicationQuit ()
    {
        lastScore += (int)score.elscore;
        PlayerPrefs.SetInt("LastScore", lastScore);
    }

    public int GetLastScore()
    {
        return PlayerPrefs.GetInt("LastScore");
    }

}
