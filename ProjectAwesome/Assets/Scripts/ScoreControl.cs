using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{

    [SerializeField] GameState state;
    public Sprite scoreWinSprite;

    void Start()
    {
        state.scoreList.Clear();
    }

    void Update()
    {
        validateScore();
    }

    void validateScore() {
        GameObject Image;

        if (state.scoreList.Count > 0)
        {
            var index = 1;
            foreach (bool scoreItem in state.scoreList)
            {
                if (index > 2) {
                    index = 2;
                }
                Image = transform.GetChild(index).gameObject;
                if (scoreItem)
                {
                    Image.GetComponent<Image>().sprite = scoreWinSprite;
                }
                index++;
            }
        }
    }
}
