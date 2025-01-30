using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] public float workTime { get; private set; }
    [SerializeField] public float timeForClick { get; private set; }
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private GameObject tableObj;
    [SerializeField] private GameObject workerObj;
    [SerializeField] private Image tableImage;
    [SerializeField] public int num;
    private bool isBuy = false;
    public int level { get; private set; }

    private void Start()
    {
        tableObj.SetActive(false);
        workerObj.SetActive(false);
        workTime = 15;
        timeForClick = 1;
        level = 0;
        lvlText.text = $"lvl: {level}";
    }

    public void LvlUp()
    {
        level++;
        workTime -= 1;
        timeForClick += 1;
        lvlText.text = $"lvl: {level}";
        if (level == 1)
        {
            tableImage.color = new Color32(255, 210, 210, 255);
        }
        else if (level == 2)
        {
            tableImage.color = new Color32(255, 185, 185, 255);
        }
        else if (level == 3)
        {
            tableImage.color = new Color32(255, 160, 160, 255);
        }
        else if (level == 4)
        {
            tableImage.color = new Color32(255, 135, 135, 255);
        }
        if (level >= 5)
        {
            lvlText.text = "Max lvl";
            tableImage.color = new Color32(255, 110, 110, 255);
        }
    }

    public void Buy()
    {
        isBuy = true;
        tableObj.SetActive(true);
        workerObj.SetActive(true);
    }
}
