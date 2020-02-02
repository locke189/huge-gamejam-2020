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
        GameObject splashAudio = GameObject.Find("MusicControllerSplash");
        Debug.Log("next");
        if (splashAudio) {
            Debug.Log("next2");
            splashAudio.GetComponent<AudioSource>().Stop();
            Destroy(splashAudio);
        }
    }
}
