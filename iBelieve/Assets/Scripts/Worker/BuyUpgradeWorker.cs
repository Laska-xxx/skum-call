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
    private ChekWorkersLvl chekWorkersLvl;
    private Coins coins;

    private AudioController audioController;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        worker = gameObject.GetComponentInParent<Worker>();
        upgradeController = FindObjectOfType<BuyUpgradeController>();
        chekWorkersLvl = FindObjectOfType<ChekWorkersLvl>();
        upgradePanel.SetActive(false);
        labelText.text = $"{worker.PersName}";
        buyButton.onClick.AddListener(BuyUpgrade);

        audioController = FindObjectOfType<AudioController>();
    }

    private void OnMouseDown()
    {
        if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !upgradePanel.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
            upgradeController.CloseAllPanels();
            DrowInfo();
            upgradePanel.SetActive(true);
            IsOpen = true;
        }
        else if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && upgradePanel.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
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
            worker.LevelUp();
            DrowInfo();
            if (worker.Level % 5 == 0)
            {
                audioController.PlayLvlUp();
                coins.AddSpecialCoins();
            }
            else
            {
                audioController.PlayBuy();
            }
        }
        if (worker.Level == 20)
        {
            infoText.text = $"Уровень: Максимальный";
            Destroy(buyButton.gameObject);
            chekWorkersLvl.ChekLvl();
        }
    }

    private void DrowInfo()
    {
        infoText.text = $"Уровень: {worker.Level}->{worker.Level + 1}\r\nЗаработок: {worker.Sallary}->{worker.FutireSallary(worker.Level + 1)} монет\r\nСтоимость: {worker.CostUpgrade}";
    }

}
