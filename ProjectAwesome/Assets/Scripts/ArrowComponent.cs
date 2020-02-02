using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowComponent : MonoBehaviour
{

    [SerializeField] GameState state;
    [SerializeField] int maxArrows = 4;
    [SerializeField] float xOffset = 100f;
    [SerializeField] float yOffset = 400f;
    [SerializeField] GameObject ArrowObject;


    Image highlight;
    Vector2 highlightPosition;
    List<GameObject> arrowList = new List<GameObject>();

    private void Start()
    {
        highlight = transform.GetChild(0).gameObject.GetComponent<Image>();
        highlightPosition = transform.GetChild(0).gameObject.transform.position;
    }

    public void SetArrows() {
        for (int i = 0; i < maxArrows; i++) {

            if (i >= state.arrows.Length) {
                return;
            }
            string currentArrow = state.arrows[i];
            Vector2 newPosition = new Vector2(highlightPosition.x, highlightPosition.y - (yOffset * i));
            GameObject arrow = Instantiate(ArrowObject, newPosition, getDirection(currentArrow));
            arrowList.Add(arrow);
            arrow.transform.parent = gameObject.transform;
        }
    }

    public void MoveUp() {
        if (state.GetHits() < state.arrows.Length) {
            RemoveFirstElement();
            ShiftUpElements();
            AddNewElement();
        }
    }

    public void RemoveFirstElement() {
        Destroy(arrowList[0]);
        arrowList.RemoveAt(0);
    }

    public void RestartArrows() {
        foreach (GameObject arrow in arrowList) {
            Destroy(arrow);
        }
        arrowList.Clear();
        SetArrows();
    }

    public void AddNewElement() {
        if ((state.GetHits() + maxArrows - 1) <= state.arrows.Length -1 )
        {
            string currentArrow = state.arrows[state.GetHits() + maxArrows - 1];
            Vector2 newPosition = new Vector2(highlightPosition.x, highlightPosition.y - (yOffset * (maxArrows - 1)));
            GameObject arrow = Instantiate(ArrowObject, newPosition, getDirection(currentArrow));
            arrowList.Add(arrow);
            arrow.transform.parent = gameObject.transform;
        }
    }

    public void ShiftUpElements()
    {
        foreach (GameObject arrow in arrowList) {
            Vector2 newPosition = new Vector2(arrow.transform.position.x, arrow.transform.position.y + yOffset);
            arrow.transform.position = newPosition;
        }
    }

    Quaternion getDirection(string direction) {
        int angle = 0;
        switch (direction)
        {
            case "UP":
                angle = 0;
                break;
            case "DOWN":
                angle = 180;
                break;
            case "LEFT":
                angle = 90;
                break;
            case "RIGHT":
                angle = 270;
                break;
            default:
                angle = 45;
                break;
        }

        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
