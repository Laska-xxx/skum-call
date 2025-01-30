using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTable : MonoBehaviour
{
    [SerializeField] private GameObject tableObj;
    [SerializeField] private GameObject buyWorkerObj;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject buyTableObj;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private int cost;
    [SerializeField] private Table table;
    [SerializeField] private Worker worker;
    [SerializeField] private Coins coins;

    private void Start()
    {

        costText.text = $"Cost: {cost}";
        tableObj.SetActive(false);
        buyWorkerObj.SetActive(false);
        buyButton.onClick.AddListener(Buy);

        if (table.num <= 0)
        {
            cost = 0;
        }
        else
        {
            cost = 10 * table.num;
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
            buyButton.interactable= true;
        }
    }

    private void Buy()
    {
        if (cost <= coins.coins)
        {
            coins.TakeCoins(cost);
            coins.AddSpecialCoins(1);
            tableObj.SetActive(true);
            buyWorkerObj.SetActive(true);
            table.Buy();
            Destroy(buyTableObj);
        }
    }
}
