using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameState state;
    SequenceGenerator ArrowSequence = new SequenceGenerator();
    SequenceGenerator ToolSequence = new SequenceGenerator();
    // Start is called before the first frame update
    void Start()
    {
        loadSet(2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadSet(int dif) {
        string[] ArrowSet = ArrowSequence.GenerateArrowSequence(dif);
        int[] ToolSet = ToolSequence.GenerateToolSequence(dif);
        Debug.Log("load set");
        state.arrows = ArrowSet;
        state.tools = ToolSet;
    }
}
