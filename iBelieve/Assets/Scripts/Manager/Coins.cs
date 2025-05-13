using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public double coins { get; private set; }
    public double specialCoins { get; private set; }

    private void Start()
    {
        coins = 10;
        specialCoins = 10;
    }

    public void AddCoins(float amount)
    {
        coins += amount;
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
}
