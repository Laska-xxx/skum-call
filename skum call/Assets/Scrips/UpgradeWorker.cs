using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWorker : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject upgradeObj;
    [SerializeField] private Worker worker;
    [SerializeField] private int cost = 10;
    [SerializeField] private int level = 1;
    [SerializeField] private Coins coins;

    private void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
    }

    private void Update()
    {
        if (!worker.isBuy)
        {
            upgradeObj.SetActive(false);
        }
        else
        {
            upgradeObj.SetActive(true);
        }
        if (cost > coins.coins)
        {
            upgradeButton.interactable = false;
        } 
        else
        {
            upgradeButton.interactable = true;
        }
    }

    private void Upgrade()
    {
        if(cost <= coins.coins)
        {
            level++;
            coins.TakeCoins(cost);
            worker.LevelUp();
            cost *= level;
        }
    }
}
