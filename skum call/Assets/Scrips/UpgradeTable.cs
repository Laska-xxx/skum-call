using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTable : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject upgradeObj;
    [SerializeField] private Table table;
    [SerializeField] private int cost = 10;
    [SerializeField] private int level = 1;
    private Coins coins;
}
