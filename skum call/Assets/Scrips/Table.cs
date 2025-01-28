using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] private GameObject[] workers;
    [SerializeField] private int cost;
    [SerializeField] private Button buyTableButton;
    private bool isBuy = false;
    [SerializeField] private Coins coins;

    private void Start()
    {
        buyTableButton.onClick.AddListener(BuyTable);
        if (!isBuy)
        {
            foreach (var worker in workers)
            {
                worker.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (!isBuy && cost > coins.coins)
        {
            buyTableButton.interactable = false;
        }
        else
        {
            buyTableButton.interactable = true;
        }
    }

    private void BuyTable()
    {
        if (!isBuy && cost <= coins.coins)
        {
            coins.TakeCoins(cost);
            isBuy = true;
            foreach (var worker in workers)
            {
                worker.SetActive(true);
            }
        }
    }
}
