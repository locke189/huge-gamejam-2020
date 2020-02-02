using UnityEngine;
using TMPro;

public class showWinnerName : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    public TMP_Text WinnerName;

    private void Start()
    {
        WinnerName.text = settings.playerWinner;
    }
}
