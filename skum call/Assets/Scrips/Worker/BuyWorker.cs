using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWorker : MonoBehaviour
{
    [SerializeField] private Worker worker;
    [SerializeField] private Button buyWorkerButton;
    [SerializeField] private GameObject buyWorkerButtonObj;
    [SerializeField] private GameObject workerUpgeadeObj;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Coins coins;
    [SerializeField] private int cost;

    private void Start()
    {
        workerUpgeadeObj.SetActive(false);
        buyWorkerButton.onClick.AddListener(Buy);
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
            buyWorkerButton.interactable = false;
        }
        else
        {
            buyWorkerButton.interactable = true;
        }
    }

    private void Buy()
    {
        if (cost <= coins.coins)
        {
            workerUpgeadeObj?.SetActive(true);
            coins.TakeCoins(cost);
            coins.AddSpecialCoins(1);
            worker.Buy();
            Destroy(buyWorkerButtonObj);
        }
    }
}
