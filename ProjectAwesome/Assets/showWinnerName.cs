using UnityEngine;
using UnityEngine.UI;

public class showWinnerName : MonoBehaviour
{
    public Text WinnerName;

    private void Start()
    {
        WinnerName.text = GameSettings.playerWinner;
    }
}
