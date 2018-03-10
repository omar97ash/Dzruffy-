using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ana m3rfsh el code da bysht3'al ezay bzabt bs hwa sha3'aal, so..

public class BackgroundScroll : MonoBehaviour {

	public float speed = 0;
	float pos = 0;
	//Renderer rend;

	// Update is called once per frame
	void Update () {
		pos += speed;
		if (pos > 1.0f)
			pos -= 1.0f; 
		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (pos, 0);
	}
}
