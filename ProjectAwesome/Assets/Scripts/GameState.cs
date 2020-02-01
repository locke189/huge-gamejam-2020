using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameState : ScriptableObject
{
    // public
    // this is an example of how to set up state variables
    // please keep them public to help debug
    public string[] arrows = {"UP","DOWN","UP","LEFT","RIGHT"};
    public int[] tools = {1,1,1,3,4};
    public int hits = 0;
    public int maxSets = 2;
    public int sets = 0;

    // constants
    public static string PLAY = "PLAY";


    // TODO: define the set of states for the game
    // PLAY: the user is playing sequences
    public string gameStateName = PLAY;


    public string GetArrow(int index) {
        return arrows[index];
    }

    public int GetTool(int index)
    {
        return tools[index];
    }

    public void NewHit() {
        hits++;
        // win conditon
        if (GetHits() >= arrows.Length)
        {
            ResetHits();
            NewSet();
            // TODO: add event.
        }
    }

    public void NewSet() {
        sets++;
        if (sets == maxSets) {
            // game over
            // TODO: add event.
        }
    }

    public void ResetHits() {
        hits = 0;
    }

    public int GetHits() {
        return hits;
    }
}   
