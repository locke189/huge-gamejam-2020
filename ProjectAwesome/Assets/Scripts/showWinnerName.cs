using UnityEngine;
using UnityEngine.UI;

public class showWinnerName : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    public Text WinnerName;

    private void Start()
    {
        WinnerName.text = settings.playerWinner;
    }
}
