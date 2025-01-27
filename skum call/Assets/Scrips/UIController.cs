using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Coins Coins;
    private void Update()
    {
        coinsText.text = $"Money: {Coins.coins}";
    }
}
