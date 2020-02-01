using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
