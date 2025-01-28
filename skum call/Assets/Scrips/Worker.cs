using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private float workTime = 1;
    [SerializeField] private float coinsPerSecond = 1;
    [SerializeField] private int cost;
    [SerializeField] private Button buyWorkerButton;
    [SerializeField] private Slider workTimeSlider;
    [SerializeField] private int num;
    [SerializeField] private int levl;
    public bool isBuy { get; private set; }
    [SerializeField] public float curWorkTime;
    [SerializeField] private Coins coins;
    [SerializeField] private ReduceTime reduceTime;

    private void Start()
    {
        curWorkTime = 0;
        isBuy = false;
        buyWorkerButton.onClick.AddListener(BuyWorker);
    }
    private void Update()
    {
        if (!isBuy && cost > coins.coins)
        {
            buyWorkerButton.interactable = false;
        }
        else
        {
            buyWorkerButton.interactable = true;
        }
        PassiveIncome();
    }

    public void BuyWorker()
    {
        if (isBuy)
        {
            reduceTime.ReduceTimeOnClik();
        }

        if (!isBuy && cost <= coins.coins)
        {
            Debug.Log("buyWorker" + num);
            coins.TakeCoins(cost);
            isBuy = true;
        }
    }
    private void PassiveIncome()
    {
        if (isBuy)
        {
            workTimeSlider.value = curWorkTime/workTime;
            curWorkTime += Time.deltaTime;
            if (curWorkTime >= workTime)
            {
                coins.AddCoins(coinsPerSecond);
                curWorkTime = 0;
                workTimeSlider.value = 0;
            }
        }
    }

    public void LevelUp()
    {
        levl++;
        coinsPerSecond += levl;
    }

}
