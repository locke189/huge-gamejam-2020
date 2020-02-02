using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] Sprite[] stage1;
    [SerializeField] Sprite[] stage2;
    [SerializeField] Sprite[] stage3;
    [SerializeField] GameState state;

    Image imageComponent;

    void Start()
    {
        imageComponent = gameObject.GetComponent<Image>();
        imageComponent.sprite = stage1[0];
    }

    // Update is called once per frame
    void Update()
    {
        float partial = calculatePercentage(state.GetHits(), state.arrows.Length);

        if (partial < 30)
        {
            imageComponent.sprite = getSprite(GetSet(), 0);
        }

        if (partial > 30 && partial < 60) {
            imageComponent.sprite = getSprite(GetSet(), 1);
        }
        if (partial > 60 )
        {
            imageComponent.sprite = getSprite(GetSet(), 2);
        }
    }

    int GetSet() {
        return state.scoreList.Count;
    }

    float calculatePercentage(int partial, float total)
    {
        float percentage = partial * 100 / total;
        return percentage;
    }

    Sprite getSprite(int set, int index) {

        if (set == 0)
        {
            return stage1[index];
        }
        else if (set == 1)
        {
            return stage2[index];
        }
        else {
            return stage3[index];
        }
    }
}

