using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] string axis = "Joystick1";
    [SerializeField] GameState state;
    [SerializeField] float debounceTime;
    string UP = "UP";
    string DOWN = "DOWN";
    string LEFT = "LEFT";
    string RIGHT = "RIGHT";
    string prevArrowKey;

    private void Start()
    {
        state.ResetHits();
    }

    void Update()
    {
        if (state.gameStateName == "PLAY")
        {
            StartCoroutine(CheckSequence(state.GetArrow(state.hits),state.GetTool(state.hits)));
        }
    }

    IEnumerator CheckSequence(string arrow, int tool) {
        yield return new WaitForSeconds(debounceTime);

        if (!IsPlayerHoldingArrow(arrow)) {
            if (CheckArrowPressed())
            {
                if (CheckArrow(arrow) && CheckTool(tool))
                {
                    Debug.Log("new hit");
                    state.NewHit();
                }
                else {
                    Debug.Log("Miss");
                    state.ResetHits();
                }
            }
        }
    }

    bool CheckArrowPressed()
    {
        float axisX = Input.GetAxis(axis + "X");
        float axisY = Input.GetAxis(axis + "Y");

        if (axisX == 1 || axisX == -1 || axisY == 1 || axisY == -1) {
            return true;
        }

        return false;
    }

    bool IsPlayerHoldingArrow(string arrowValue) {
        float axisX = Input.GetAxis(axis + "X");
        float axisY = Input.GetAxis(axis + "Y");
        if (arrowValue == prevArrowKey) {
            if (axisX == 1 || axisX == -1 || axisY == 1 || axisY == -1)
            {
                return true;
            }
            prevArrowKey = "";
        }
        return false;
    }

    bool CheckArrow(string arrowValue) {
        string currentArrow;
        float axisX = Input.GetAxis(axis + "X");
        float axisY = Input.GetAxis(axis + "Y");


        if (arrowValue == UP && axisY == -1) {
            currentArrow = UP;
            if (currentArrow != prevArrowKey)
            {
                prevArrowKey = UP;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (arrowValue == DOWN && axisY == 1) {
            currentArrow = DOWN;
            if (currentArrow != prevArrowKey)
            {
                prevArrowKey = DOWN;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (arrowValue == RIGHT && axisX == 1)
        {
            currentArrow = RIGHT;
            if (currentArrow != prevArrowKey)
            {
                prevArrowKey = RIGHT;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (arrowValue == LEFT && axisX == -1)
        {
            currentArrow = LEFT;
            if (currentArrow != prevArrowKey)
            {
                prevArrowKey = LEFT;
                return true;
            }
            else
            {
                return false;
            }
        }

        prevArrowKey = "";
        return false;
    }

    bool CheckTool(int ToolCode) {
        float button0 = Input.GetAxis(axis + "A");
        float button1 = Input.GetAxis(axis + "B");
        float button2 = Input.GetAxis(axis + "C");
        float button3 = Input.GetAxis(axis + "D");

        if (ToolCode == 1 && button0 == 1)
        {
            return true;
        }
        else if (ToolCode == 2 && button1 == 1)
        {
            return true;
        }
        else if (ToolCode == 3 && button2 == 1)
        {
            return true;
        }
        else if (ToolCode == 4 && button3 == 1)
        {
            return true;
        }

        return false;
    }
}
