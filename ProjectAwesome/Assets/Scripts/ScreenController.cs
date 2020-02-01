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
        SceneManager.LoadScene(index + 1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
