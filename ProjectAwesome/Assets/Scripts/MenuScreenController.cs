using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public InputField playerOneName;
    public InputField playerTwoName;

    public void startGame()
    {
        Debug.Log("Player 1 name: " + playerOneName.text);
        Debug.Log("Player 2 name: " + playerTwoName.text);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
