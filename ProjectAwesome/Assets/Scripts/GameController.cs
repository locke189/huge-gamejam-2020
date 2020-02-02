using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] GameState state;
    [SerializeField] GameState state2;
    [SerializeField] GameSettings settings;
    [SerializeField] UnityEvent onSetupComplete;
    SequenceGenerator ArrowSequence = new SequenceGenerator();
    SequenceGenerator ToolSequence = new SequenceGenerator();
    
    // Start is called before the first frame update
    void Start()
    {
        state.gameStateName = "SETUP";
        state2.gameStateName = "SETUP";
        loadSet();
        //starts the gaming sequence
        onSetupComplete.Invoke();
        state.gameStateName = "PLAY";
        state2.gameStateName = "PLAY";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadSet() {
        int dif = settings.difficulty;
        string[] ArrowSet = ArrowSequence.GenerateArrowSequence(dif);
        int[] ToolSet = ToolSequence.GenerateToolSequence(dif);
        Debug.Log("load set");
        Array.Resize(ref state.arrows, ArrowSet.Length);
        Array.Resize(ref state2.arrows, ArrowSet.Length);
        Array.Resize(ref state.tools, ToolSet.Length);
        Array.Resize(ref state2.tools, ToolSet.Length);
        state.arrows = ArrowSet;
        state2.arrows = ArrowSet;
        state.tools = ToolSet;
        state2.tools = ToolSet;
    }

}
