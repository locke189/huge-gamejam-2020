using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{

    [SerializeField] string axis = "Joystick1";
    [SerializeField] GameState state;
    [SerializeField] GameSettings settings;
    [SerializeField] bool player1;
    [SerializeField] float debounceTime;
    [SerializeField] UnityEvent OnSetComplete;
    [SerializeField] UnityEvent OnGameComplete;
    [SerializeField] UnityEvent OnHit;
    [SerializeField] UnityEvent OnHitReset;


    string prevArrowKey;

    // Constants
    readonly string UP = "UP";
    readonly string DOWN = "DOWN";
    readonly string LEFT = "LEFT";
    readonly string RIGHT = "RIGHT";
    readonly string PLAY_STATE = "PLAY";
    readonly string X_AXIS = "X";
    readonly string Y_AXIS = "Y";
    readonly string BUTTON_1 = "A";
    readonly string BUTTON_2 = "B";
    readonly string BUTTON_3 = "C";
    readonly string BUTTON_4 = "D";


    private void Start()
    {
        state.ResetHits();
        state.sets = 0;
        state.scoreList.Clear();
    }

    void Update()
    {
        if (state.gameStateName == PLAY_STATE)
        {
            //Debug.Log(state.GetArrow(state.GetHits()));
            //Debug.Log(state.GetTool(state.GetHits()));
            StartCoroutine(CheckSequence(state.GetArrow(state.GetHits()), state.GetTool(state.GetHits())));
        }
    }

    IEnumerator CheckSequence(string arrow, int tool)
    {
        yield return new WaitForSeconds(debounceTime);

        if (!IsPlayerHoldingArrow(arrow))
        {
            if (CheckArrowPressed())
            {
                if (CheckArrow(arrow) && CheckTool(tool))
                {
                    Debug.Log("new hit");
                    Debug.Log(state.GetArrow(state.GetHits()));
                    Debug.Log(state.GetTool(state.GetHits()));
                    state.NewHit();
                    OnHit.Invoke();

                    if (state.GetHits() == state.arrows.Length)
                    {
                        state.NewSet();

                        if (state.sets == state.maxSets)
                        {
                            if (player1)
                            {
                                settings.playerWinner = settings.playerOneName;
                            }
                            else
                            {
                                settings.playerWinner = settings.playerTwoName;
                            }
                            OnGameComplete.Invoke();
                        }

                        state.ResetHits();
                        OnSetComplete.Invoke();
                    }
                }
                else
                {
                    Debug.Log("Miss");
                    Debug.Log(state.GetArrow(state.GetHits()));
                    Debug.Log(state.GetTool(state.GetHits()));
                    state.ResetHits();
                    OnHitReset.Invoke();
                }
            }
        }
    }

    bool CheckArrowPressed()
    {
        float axisX = Input.GetAxis(axis + X_AXIS);
        float axisY = Input.GetAxis(axis + Y_AXIS);
        bool APress = Input.GetKeyDown(KeyCode.A);
        bool SPress = Input.GetKeyDown(KeyCode.S);
        bool DPress = Input.GetKeyDown(KeyCode.D);
        bool WPress = Input.GetKeyDown(KeyCode.W);

        if (APress)
        {
            axisX = -1;
            Debug.Log("a press" + axisX);

        }
        else if (DPress)
        {
            axisX = 1;
            Debug.Log("a press" + axisX);
        }
        else if (SPress)
        {
            axisY = 1;
            Debug.Log("a press" + axisY);
        }
        else if (WPress)
        {
            Debug.Log("a press" + axisY);
            axisY = -1;
        }

        if (axisX == 1 || axisX == -1 || axisY == 1 || axisY == -1)
        {
            return true;
        }

        return false;
    }

    bool IsPlayerHoldingArrow(string arrowValue)
    {
        float axisX = Input.GetAxis(axis + X_AXIS);
        float axisY = Input.GetAxis(axis + Y_AXIS);

        if (prevArrowKey == UP && axisY == -1 ||
            prevArrowKey == DOWN && axisY == 1 ||
            prevArrowKey == RIGHT && axisX == 1 ||
            prevArrowKey == LEFT && axisX == -1)
        {
            return true;
        }
        else
        {
            prevArrowKey = "";
            return false;
        }
    }

    bool CheckArrow(string arrowValue)
    {
        string currentArrow;
        float axisX = Input.GetAxis(axis + X_AXIS);
        float axisY = Input.GetAxis(axis + Y_AXIS);


        bool APress = Input.GetKeyDown(KeyCode.A);
        bool SPress = Input.GetKeyDown(KeyCode.S);
        bool DPress = Input.GetKeyDown(KeyCode.D);
        bool WPress = Input.GetKeyDown(KeyCode.W);

        if (APress)
        {
            axisX = -1;
            Debug.Log("a press" + axisX);

        }
        else if (DPress)
        {
            axisX = 1;
            Debug.Log("a press" + axisX);
        }
        else if (SPress)
        {
            axisY = 1;
            Debug.Log("a press" + axisY);
        }
        else if (WPress)
        {
            Debug.Log("a press" + axisY);
            axisY = -1;
        }


        if (arrowValue == UP && axisY == -1)
        {
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
        else if (arrowValue == DOWN && axisY == 1)
        {
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

    bool CheckTool(int ToolCode)
    {
        float button0 = Input.GetAxis(axis + BUTTON_1);
        float button1 = Input.GetAxis(axis + BUTTON_2);
        float button2 = Input.GetAxis(axis + BUTTON_3);
        float button3 = Input.GetAxis(axis + BUTTON_4);

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
