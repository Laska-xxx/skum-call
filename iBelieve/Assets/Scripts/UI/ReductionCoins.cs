using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReductionCoins : MonoBehaviour
{
    public string Reduction(double value)
    {
        if (value >= 1000000000000000)
        {
            return (value / 1000000000000000).ToString("#.#") + "Q";
        }
        else if (value >= 1000000000000)
        {
            return (value / 1000000000000).ToString("#.#") + "T";
        }
        else if (value >= 1000000000)
        {
            return (value / 1000000000).ToString("#.#") + "B";
        }
        else if (value >= 1000000)
        {
            return (value / 1000000).ToString("#.#") + "M";
        }
        else if (value >= 1000)
        {
            return (value / 1000).ToString("#.#") + "K";
        }
        else
        {
            return value.ToString();
        }
    }
}
