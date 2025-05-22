using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyBuster : MonoBehaviour
{
    [SerializeField] private BusterData busterData;
    private TextMeshProUGUI costText;
    private Button button;
    private Coins coins;
    private Shop shop;

    void Start()
    {
        button = GetComponent<Button>();  
        costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = busterData.Cost.ToString();
        coins = FindObjectOfType<Coins>();
        shop = FindObjectOfType<Shop>();
        button.onClick.AddListener(BuyClick);
    }
    private void BuyClick()
    {
        if (coins.specialCoins >= busterData.Cost)
        {
            coins.TakeSpecialCoins(busterData.Cost);
            if (busterData.IsDobleSallaryBuster)
            {
                shop.DobleSellary(busterData.Time);
            }
            else
            {
                shop.SkipTime(busterData.Time);
            }
        }
    }
}
