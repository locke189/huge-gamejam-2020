using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{

    [SerializeField] GameState state;

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
            var index = 0;
            foreach (bool scoreItem in state.scoreList)
            {
                
                Debug.Log(index);
                Image = transform.GetChild(index).gameObject;
                if (scoreItem)
                {
                    Image.GetComponent<Image>().color = new Color(0, 255, 0, 1);
                }
                else
                {
                    Image.GetComponent<Image>().color = new Color(255, 0, 0, 1);
                }
                index++;
            }
        }
    }
}
