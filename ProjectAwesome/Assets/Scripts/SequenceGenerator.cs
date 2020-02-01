using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public struct Pair
{
    public int Tool;
    public string Arrow;
    public Pair(int tool, string arrow)
    {
        Tool = tool;
        Arrow = arrow;
    }
}

public class SequenceGenerator : MonoBehaviour
{
    public int difficulty = 3;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSequence(difficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public Pair[] GenerateSequence(int difficulty) {

        Pair[] Sequence = new Pair[difficulty*10];

        int[] AvailableTools = { 1, 2, 3, 4 };

        int[] SelectedTools = new int[difficulty + 1];

        System.Random rand = new System.Random();

        for (int i = 0; i <= difficulty; i++)
        {
            int randomTool = rand.Next(0, 3);
            Debug.Log("i" + i);
            Debug.Log("heramienta disponible seleccionada" + AvailableTools[randomTool]);
            Debug.Log("array selected:" + SelectedTools);
            SelectedTools[i] = AvailableTools[randomTool];
            Debug.Log("array selected:" + SelectedTools[i]);
            AvailableTools = Array.FindAll(AvailableTools, val => val != randomTool);

        }

        string[] Arrows = { "UP", "DOWN", "LEFT", "RIGHT" };

        for (int i = 0; i < difficulty*10; i++)
        {
            Debug.Log("entry added");
            int pairToolPos = rand.Next(0, SelectedTools.Length);
            int pairArrowPos = rand.Next(0, 3);
            Pair entry = new Pair(SelectedTools[pairToolPos], Arrows[pairArrowPos]);
            Sequence[i] = entry;
            Debug.Log("entry added");
            Debug.Log(Sequence[i].Tool);
        }

        Debug.Log(Sequence);
        return Sequence;

    }

}
