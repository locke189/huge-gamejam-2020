using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
	[SerializeField] float delay = 3f;
    [SerializeField] string sceneToLoad = "MainScreen";
    [SerializeField] bool onStart = true;

	void Start() {
		if (onStart) {
			StartCoroutine(LoadSceneDelayed(sceneToLoad));
        }
    }

	IEnumerator LoadSceneDelayed(string sceneLabel) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneLabel);
    }


	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainScreen");
	}


	public void LoadNextScreen()
	{
		int index = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("next");
		if (index + 1 > 1)
		{
			Debug.Log("next");
			GameObject splashAudio = GameObject.Find("MusicControllerSplash");
			splashAudio.GetComponent<AudioSource>().Stop();
			Destroy(splashAudio);
		}

		SceneManager.LoadScene(index + 1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
