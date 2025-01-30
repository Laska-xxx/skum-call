using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] public float coinsPerSecond {  get; private set; }
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private Button buyWorkerButton;
    [SerializeField] private Slider workTimeSlider;
    [SerializeField] public int num;
    [SerializeField] public int level {  get; private set; }
    public bool isBuy { get; private set; }
    [SerializeField] public float curWorkTime;
    [SerializeField] private Coins coins;
    [SerializeField] private Table table;
    [SerializeField] private Image image;
    [SerializeField] private ReduceTime reduceTime;

    private void Start()
    {
        curWorkTime = 0;
        coinsPerSecond = 1;
        level = 0;
        isBuy = false;
        buyWorkerButton.onClick.AddListener(StartWork);
        lvlText.text = $"Lvl: {level}";
    }
    private void Update()
    {
        PassiveIncome();
    }

    public void StartWork()
    {
        if (isBuy)
        {
            reduceTime.ReduceTimeOnClik();
            
        }
    }
    private void PassiveIncome()
    {
        if (isBuy)
        {
            workTimeSlider.value = curWorkTime/table.workTime;
            curWorkTime += Time.deltaTime;
            if (curWorkTime >= table.workTime)
            {
                coins.AddCoins(coinsPerSecond);
                curWorkTime = 0;
                workTimeSlider.value = 0;
            }
        }
    }

    public void LevelUp()
    {
        level++;
        coinsPerSecond += level;
        lvlText.text = $"Lvl: {level}";
        if (level == 1)
        {
            image.color = new Color32(218, 255, 213, 255);
        }
        else if (level == 2)
        {
            image.color = new Color32(195, 255, 195, 255);
        }
        else if (level == 3)
        {
            image.color = new Color32(170, 255, 170, 255);
        }
        else if (level == 4)
        {
            image.color = new Color32(140, 255, 140, 255);
        }
        else if (level >= 5)
        {
            image.color = new Color32(110, 255, 110, 255);
            lvlText.text = "Max lvl";
        }
    }

    public void Buy()
    {
        isBuy = true;
    }

}
