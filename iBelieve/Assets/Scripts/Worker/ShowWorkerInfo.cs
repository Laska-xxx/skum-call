using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWorkerInfo : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] private TextMeshProUGUI infoText;
    private Worker worker;
    private Desk desk;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private ReductionCoins reductionCoins;
    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        reductionCoins = FindObjectOfType<ReductionCoins>();
        worker = gameObject.GetComponentInParent<Worker>();
        desk = gameObject.GetComponentInParent<Desk>();
        infoPanel.SetActive(false);
        labelText.text = $"{worker.PersName}";
    }

    private void OnMouseOver()
    {
        if (!menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen) 
        {
            infoText.text = $"Заработок:{reductionCoins.Reduction(worker.Sallary)}\r\nКулдаун: {desk.Cooldown}";
            infoPanel.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
