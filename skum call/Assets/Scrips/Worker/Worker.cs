using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] public float coinsPerSecond {  get; private set; }
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private Button workerButton;
    [SerializeField] private Slider workTimeSlider;
    [SerializeField] public int num;
    [SerializeField] public int level {  get; private set; }
    public bool isBuy { get; private set; }
    [SerializeField] public float curWorkTime;
    [SerializeField] private Coins coins;
    [SerializeField] private Table table;
    [SerializeField] private ReduceTime reduceTime;
    [SerializeField] public Sprite[] lvlUpSprits;

    private void Start()
    {
        GetComponent<Image>().sprite = lvlUpSprits[0];
        curWorkTime = 0;
        coinsPerSecond = 1;
        level = 0;
        isBuy = false;
        workerButton.onClick.AddListener(ReduceTime);
        lvlText.text = $"Lvl: {level}";
    }
    private void Update()
    {
        PassiveIncome();
    }

    public void ReduceTime()
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
        if (level >= 5)
        {
            GetComponent<Image>().sprite = lvlUpSprits[1];
            lvlText.text = "Max lvl";
        }
    }

    public void Buy()
    {
        isBuy = true;
    }

}
