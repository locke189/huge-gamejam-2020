using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    public InputField playerOneName;
    public InputField playerTwoName;

    public void startGame()
    {
        settings.playerOneName = playerOneName.text;
        settings.playerTwoName = playerTwoName.text;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setEasy()
    {
        settings.difficulty = 1;
    }

    public void setMedium()
    {
        settings.difficulty = 2;
    }

    public void setHard()
    {
        settings.difficulty = 3;
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
