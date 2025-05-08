using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Button shopButton;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsPanel;
    public bool ShopOpen = false;
    public bool SettingsOpen = false;
    private Coins coins;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        shopButton.onClick.AddListener(ShowShop);
        settingsButton.onClick.AddListener(ShowSettings);
    }

    void Update()
    {
        coinsText.text = coins.coins.ToString();
    }

    private void ShowShop()
    {
        shopPanel.SetActive(true);
        ShopOpen = true;
    }

    private void ShowSettings()
    {
        settingsPanel.SetActive(true);
        SettingsOpen = true;
    }
}
