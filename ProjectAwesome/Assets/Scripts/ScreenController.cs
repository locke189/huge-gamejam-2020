using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
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
