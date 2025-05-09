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
        labelText.GetComponent<TextMeshProUGUI>().text = $"{worker.PersName}";
    }

    private void OnMouseOver()
    {
        if (!menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen) 
        {
            infoText.GetComponent<TextMeshProUGUI>().text = $"Sallary:{worker.Sallary} coins\r\nCooldown: {desk.Cooldown} sec";
            infoPanel.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
