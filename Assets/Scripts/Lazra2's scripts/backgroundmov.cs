using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmov : MonoBehaviour {
	public GameObject prefab;
	public float spawntime=3;
	// Use this for initialization
	void Start () {

		//InvokeRepeating ("Spawn", spawntime, spawntime);
		Vector3 pospos = new Vector3 (17.85f, 0, 0);
		Instantiate (prefab, pospos, Quaternion.identity);
		StartCoroutine("SpawnRoutine");
	}

	void Spawn(){
		Vector3 newpos = new Vector3 (17.91f, 0, 0);
		Instantiate (prefab, newpos, Quaternion.identity);

	}

	IEnumerator SpawnRoutine()
	{
		while (true) {
			yield return new WaitForSeconds (spawntime);
			Spawn ();
		}
	}

	// Update is called once per frame
	void Update () {
	}
}

