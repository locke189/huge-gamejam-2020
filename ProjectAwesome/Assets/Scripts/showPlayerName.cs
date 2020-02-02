using UnityEngine;
using UnityEngine.UI;

public class showPlayerName : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    public Text PlayerName;
    public int PlayerNumber;

    private void Start()
    {
        if(PlayerNumber == 1)
        {
            PlayerName.text = settings.playerOneName;
        }
        else
        {
            PlayerName.text = settings.playerTwoName;
        }
    }
}
