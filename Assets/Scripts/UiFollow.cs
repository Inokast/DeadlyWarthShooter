using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFollow : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;

    // Update is called once per frame
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (objectToFollow != null) 
        {
            rectTransform.anchoredPosition = objectToFollow.localPosition;
        }
    }
}
