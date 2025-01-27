using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public double coins = 0;

    public void AddCoins(float amount)
    {
        coins += amount;
    }

    public void TakeCoins(float cost)
    {
        coins -= cost;
    }
}
