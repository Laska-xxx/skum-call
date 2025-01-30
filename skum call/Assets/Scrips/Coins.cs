using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public double coins;
    public double specialCoins { get; private set; }

    private void Start()
    {
        coins = 0;
        specialCoins = 0;
    }

    public void AddCoins(float amount)
    {
        coins += amount;
    }

    public void TakeCoins(float amount)
    {
        coins -= amount;
    }

    public void AddSpecialCoins(float amount)
    {
        specialCoins += amount;
    }

    public void TakeSpecialCoins(float amount)
    {
        specialCoins -= amount;
    }
}
