using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameSettings : ScriptableObject
{
    public int difficulty = 1;
    public string playerOneName = "Player 1";
    public string playerTwoName = "Player 2";
    public static string playerWinner = "WinnerName";
}
