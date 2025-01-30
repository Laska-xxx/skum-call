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
        workTime -= level;
        timeForClick += level;
        lvlText.text = $"lvl: {level}";
    }

    public void Buy()
    {
        isBuy = true;
        tableObj.SetActive(true);
        workerObj.SetActive(true);
    }
}
