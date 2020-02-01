using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightButton : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] string axis;

    Image componentImage;

    private void Start()
    {
        componentImage = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(axis) == 1) {
            componentImage.color = color;
        }

        else {
            componentImage.color = Color.white;
        }
    }
}
