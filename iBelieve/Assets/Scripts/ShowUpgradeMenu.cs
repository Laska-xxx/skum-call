using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBg;
    private BuyUpgradeController upgradeController;
    public bool UpgradeMenuOpen { get; private set; }
    void Start()
    {
        UpgradeMenuOpen = false;
        menuBg.SetActive(false);
        upgradeController = FindObjectOfType<BuyUpgradeController>();
    }

    private void OnMouseDown()
    {
        if (UpgradeMenuOpen)
        {
            UpgradeMenuOpen = false;
            menuBg.SetActive(false);
            upgradeController.CloseAllPanels();
        }
        else
        {
            UpgradeMenuOpen = true;
            menuBg.SetActive(true);
        }
    }
}
