using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeWorker : MonoBehaviour
{
    public bool IsOpen { get; private set; } = false;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Button buyButton;
    private Worker worker;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private BuyUpgradeController upgradeController;
    private Coins coins;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        worker = gameObject.GetComponentInParent<Worker>();
        upgradeController = FindObjectOfType<BuyUpgradeController>();
        upgradePanel.SetActive(false);
        labelText.GetComponent<TextMeshProUGUI>().text = $"{worker.PersName}";
        buyButton.onClick.AddListener(BuyUpgrade);
    }

    private void OnMouseDown()
    {
        if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !upgradePanel.activeInHierarchy)
        {
            upgradeController.CloseAllPanels();
            DrowInfo();
            upgradePanel.SetActive(true);
            IsOpen = true;
        }
        else
        {
            Close();
        }
    }
    public void Close()
    {
        upgradePanel.SetActive(false);
        IsOpen=false;
    }
    private void BuyUpgrade()
    {
        if (coins.coins >= worker.CostUpgrade)
        {
            coins.TakeCoins(worker.CostUpgrade);
            coins.AddSpecialCoins();
            worker.LevelUp();
            DrowInfo();
        }
    }

    private void DrowInfo()
    {
        infoText.GetComponent<TextMeshProUGUI>().text = $"Уровень: {worker.Level}->{worker.Level + 1}\r\nЗаработок: {worker.Sallary}->{worker.FutireSallary(worker.Level + 1)} монет\r\nСтоимость: {worker.CostUpgrade}";
    }

}
