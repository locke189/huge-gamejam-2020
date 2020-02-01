using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SequenceGenerator : MonoBehaviour
{
    public System.Random rand = new System.Random();

    //public Pair[] GenerateSequence(int difficulty) {

    //    Pair[] Sequence = new Pair[difficulty*10];

    //    int[] AvailableTools = { 1, 2, 3, 4 };

    //    int[] SelectedTools = new int[difficulty + 1];



    //    for (int i = 0; i <= difficulty; i++)
    //    {
    //        int randomTool = rand.Next(0, 3);
    //        SelectedTools[i] = AvailableTools[randomTool];
    //        AvailableTools = Array.FindAll(AvailableTools, val => val != randomTool);

    //    }

    //    string[] Arrows = { "UP", "DOWN", "LEFT", "RIGHT" };

    //    for (int i = 0; i < difficulty*10; i++)
    //    {
    //        Debug.Log("entry added");
    //        int pairToolPos = rand.Next(0, SelectedTools.Length);
    //        int pairArrowPos = rand.Next(0, 3);
    //        Pair entry = new Pair(SelectedTools[pairToolPos], Arrows[pairArrowPos]);
    //        Sequence[i] = entry;
    //    }
    //    return Sequence;

    //}

    public int[] GenerateToolSequence(int difficulty) {
        int[] Sequence = new int[difficulty * 10];

        int[] AvailableTools = { 1, 2, 3, 4 };

        int[] SelectedTools = new int[difficulty + 1];

        for (int i = 0; i <= difficulty; i++)
        {
            int randomTool = rand.Next(0, 3);
            SelectedTools[i] = AvailableTools[randomTool];
            AvailableTools = Array.FindAll(AvailableTools, val => val != randomTool);

        }
        for (int i = 0; i < difficulty * 10; i++)
        {
            int toolPos = rand.Next(0, SelectedTools.Length);
            int entry = SelectedTools[toolPos];
            Sequence[i] = entry;
        }
        return Sequence;
    }

    public String[] GenerateArrowSequence(int difficulty) {
        String[] Sequence = new String[difficulty * 10];
        string[] Arrows = { "UP", "DOWN", "LEFT", "RIGHT" };
        for (int i = 0; i < difficulty * 10; i++)
        {
            int arrowPos = rand.Next(0, 3);
            String entry = Arrows[arrowPos];
            Sequence[i] = entry;
        }
        return Sequence;
    }

}
