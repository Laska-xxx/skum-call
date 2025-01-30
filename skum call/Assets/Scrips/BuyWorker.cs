using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWorker : MonoBehaviour
{
    [SerializeField] private Worker worker;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject workerObj;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Coins coins;
    [SerializeField] private int cost;

    private void Start()
    {
        workerObj.SetActive(false);
        buyButton.onClick.AddListener(Buy);
        if (worker.num <= 0)
        {
            cost = 0;
        }
        else
        {
            cost = 10 * worker.num;
        }
        costText.text = $"Cost: {cost}";
    }

    private void Update()
    {
        if (cost > coins.coins)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    private void Buy()
    {
        if (cost <= coins.coins)
        {
            workerObj?.SetActive(true);
            coins.TakeCoins(cost);
            worker.Buy();
            Destroy(buyButton);
        }
    }
}
