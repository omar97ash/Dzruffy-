using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	public GameObject[] prefab; //Defines a dynamic array for prefabs
	public float MIN_TTS=0.5f; 	//Minimum time taken to spawn a new object
	public float MAX_TTS=1f; 	//Maximum time taken to spawn a new object
	public float SpnBtnObj=1f; // ??

	void Start () {
		StartCoroutine("SpawnRoutine");
	}

	void Spawn(){
		int index = Random.Range (0, prefab.Length); //Selects a random index number between 0 and N prefabs.
		Instantiate (prefab[index], new Vector3 (Random.Range(11f, 20f), Random.Range (-2.5f, 4.71f), 0), Quaternion.identity);
	}

	IEnumerator SpawnRoutine()
	{
		while (true) {
			int index = Random.Range (0, prefab.Length);
			Instantiate (prefab[index], new Vector3 (Random.Range(11f, 20f), Random.Range (-2.5f, 4.71f), 0), Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(MIN_TTS, MAX_TTS)); //Waits for N number of seconds (randomly selected between 2 variables)
			Spawn ();
		}
	}
}