using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseChooseWorker : MonoBehaviour
{
    private bool isInArea = false;
   
    private void OnMouseOver()
    {
        isInArea = true;
    }

    private void OnMouseExit()
    {
        if (isInArea)
        {
            isInArea = false;
            gameObject.SetActive(false);
        }
    }
}
