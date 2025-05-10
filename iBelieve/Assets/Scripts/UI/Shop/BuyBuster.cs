using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBuster : MonoBehaviour
{
    [SerializeField] private Busters busterData;
    private Button button;
    private Coins coins;
    private Shop shop;

    void Start()
    {
        button = GetComponent<Button>();   
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
