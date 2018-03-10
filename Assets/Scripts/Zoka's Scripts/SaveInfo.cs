using UnityEngine;
public class SaveInfo : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }

	void Save ()
	{
		PlayerPrefs.SetFloat ("Score", score.elscore);
		PlayerPrefs.Save ();
	}

}