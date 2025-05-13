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
    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        worker = gameObject.GetComponentInParent<Worker>();
        desk = gameObject.GetComponentInParent<Desk>();
        infoPanel.SetActive(false);
        labelText.text = $"{worker.PersName}";
    }

    private void OnMouseOver()
    {
        if (!menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen) 
        {
            infoText.text = $"Заработок:{worker.Sallary} монет\r\nКулдаун: {desk.Cooldown} сек";
            infoPanel.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
