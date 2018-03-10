using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Delay : MonoBehaviour {
	public ParticleSystem fast_particles;
	public ParticleSystem slow_particles;
	// Use this for initialization
	void Start () {
		//defines variable to control the emission module
		ParticleSystem.EmissionModule em = fast_particles.emission;

		//Emission control
		em.enabled = false;

		StartCoroutine ("EmissionHandler");	//Starts the particle emission handler
	}

	IEnumerator EmissionHandler()
	{
		ParticleSystem.EmissionModule em = fast_particles.emission;
		ParticleSystem.EmissionModule em1 = slow_particles.emission;

		yield return new WaitForSeconds (69); //A timer that waits for 69 seconds

		em1.enabled = false;
		em.enabled = true;

		yield return new WaitForSeconds (116);

		em.enabled = false;
		em1.enabled = true;
	}
}
