using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI coinsText2;
    [SerializeField] private Coins Coins;
    private void Update()
    {
        coinsText.text = $"Money: {Coins.coins}";
        coinsText2.text = $"Money: {Coins.coins}";
    }
}
