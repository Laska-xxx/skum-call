using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialCheckClick : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    private int curClick = 6;
    
    public bool ClicksComplete()
    {
        return curClick <= 0;
    }
    private void OnMouseDown()
    {
        curClick--;
        triggerText.text = $"{curClick} клик..";
    }
}
