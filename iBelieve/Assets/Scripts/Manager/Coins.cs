using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public double coins { get; private set; } = 0;
    public double specialCoins { get; private set; } = 0;
    private AchivController achivController;

    private void Start()
    {
        achivController = FindObjectOfType<AchivController>();
    }
    public void AddCoins(float amount)
    {
        coins += amount;
        achivController.GetMoneyAchiv(coins);
    }
    public void TakeCoins(float amount)
    {
        coins -= amount;
    }
    public void AddSpecialCoins(float amount = 1)
    {
        specialCoins += amount;
    }
    public void TakeSpecialCoins(float amount)
    {
        specialCoins -= amount;
    }
    public void LoadCoinsValue(double coinsValue, double specialCoinsValue)
    {
        coins = coinsValue;
        specialCoins = specialCoinsValue;
    }
}
