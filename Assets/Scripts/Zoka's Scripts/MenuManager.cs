using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    PlayerHealth pH;

    void Awake()
    {
        pH = GetComponent<PlayerHealth>();
    }

	public void StartGame ()
	{
		SceneManager.LoadScene ("La7mar");
        //LoadInfo.LoadScore();
    }

	public void Continue ()
	{
        SceneManager.LoadScene ("La7mar");
        //LoadInfo.LoadScore();
    }
	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;

		#else
		Application.Quit();
		#endif
	}
}
