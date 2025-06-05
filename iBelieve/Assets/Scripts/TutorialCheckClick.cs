using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialCheckClick : MonoBehaviour
{
    private int curClick = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            curClick++;
        }
        if (curClick >= 5)
        {
            ClicksComplete();
        }
    }
    public bool ClicksComplete()
    {
        return true;
    }
}
