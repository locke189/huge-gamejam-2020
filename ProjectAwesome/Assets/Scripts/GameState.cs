using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameState : ScriptableObject
{
    // public
    // this is an example of how to set up state variables
    // please keep them public to help debug
    public int[] sequence = {1,2,1,3,4};
    public int[] tools = {1,1,1,3,4};
    public int hits = 0;


    // returns an array t
    public int[] GetCommands(int index) {
        int[] nextCommand = { sequence[index], tools[index] };
        return nextCommand;
    }

    public void NewHit() {
        hits++;
    }
}
