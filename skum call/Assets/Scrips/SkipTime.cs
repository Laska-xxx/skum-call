using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipTime : MonoBehaviour
{
    [SerializeField] private Button skipTimeButton;

    private void Start()
    {
        skipTimeButton.onClick.AddListener(Skip);
    }

    private void Skip()
    {
        Time.timeScale = 2;
    }
}
