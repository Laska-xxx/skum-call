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
    [SerializeField] public int num;
    [SerializeField] private GameObject[] lvlUpObj;
    private bool isBuy = false;
    public int level { get; private set; }

    private void Start()
    {
        lvlUpObj[level].SetActive(true);
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
        for (int i = 0; i < lvlUpObj.Length;  i++)
        {
            if (i+1 == level)
            {
                lvlUpObj[i].SetActive(true);
            }
            else
            {
                lvlUpObj[i].SetActive(false);
            }
        }
        if (level >= 5)
        {
            lvlText.text = "Max lvl";
        }
    }

    public void Buy()
    {
        isBuy = true;
        tableObj.SetActive(true);
        workerObj.SetActive(true);
    }
}
