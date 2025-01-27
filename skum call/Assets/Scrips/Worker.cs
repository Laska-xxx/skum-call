using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private int workTime = 1;
    [SerializeField] private float coinsPerSecond = 1;
    [SerializeField] private int cost;
    [SerializeField] private Button buyWorkerButton;
    private bool isBuy = false;
    [SerializeField] private float curWorkTime;
    [SerializeField] private Coins coins;

    private void Start()
    {
        buyWorkerButton.onClick.AddListener(BuyWorker);
        curWorkTime = workTime;
    }
    private void Update()
    {
        if (isBuy)
        {
            curWorkTime -= Time.deltaTime;
            if(curWorkTime<= 0 )
            {
                coins.AddCoins(coinsPerSecond);
                curWorkTime = workTime;
            }
        }
    }

    public void BuyWorker()
    {
        if (isBuy)
        {
            curWorkTime -= 1f;
        }

        else
        {
            if (cost <= coins.coins)
            {
                Debug.Log("click");
                coins.TakeCoins(cost);
                isBuy = true;

            }
        }
    }
}
