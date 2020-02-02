using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScreenController : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    public TMP_InputField playerOneName;
    public TMP_InputField playerTwoName;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    [SerializeField] Sprite[] sprites;

    Image easyImage;
    Image mediumImage;
    Image hardImage;
    
    public void Start()
    {
        easyImage = easyButton.GetComponent<Image>();
        mediumImage = mediumButton.GetComponent<Image>();
        hardImage = hardButton.GetComponent<Image>();

        settings.playerOneName = "Player 1";
        settings.playerTwoName = "Player 2";
        settings.difficulty = 1;
        setEasy();
    }

    public void startGame()
    {
        if (playerOneName.text != "")
        {
            settings.playerOneName = playerOneName.text;
        }

        if (playerTwoName.text != "")
        {
            settings.playerTwoName = playerTwoName.text;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject splashAudio = GameObject.Find("MusicControllerSplash");
        Debug.Log("next");
        if (splashAudio)
        {
            Debug.Log("next2");
            splashAudio.GetComponent<AudioSource>().Stop();
            Destroy(splashAudio);
        }
    }

    public void setEasy()
    {
        easyImage.sprite = sprites[1];
        mediumImage.sprite = sprites[0];
        hardImage.sprite = sprites[0];
        settings.difficulty = 1;
    }

    public void setMedium()
    {
        easyImage.sprite = sprites[0];
        mediumImage.sprite = sprites[2];
        hardImage.sprite = sprites[0];
        settings.difficulty = 2;
    }

    public void setHard()
    {
        easyImage.sprite = sprites[0];
        mediumImage.sprite = sprites[0];
        hardImage.sprite = sprites[3];
        settings.difficulty = 3;
    }
}
