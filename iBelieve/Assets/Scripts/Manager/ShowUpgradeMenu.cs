using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBg;
    private BuyUpgradeController upgradeController;
    private AudioController audioController;
    private BuyWorker curBuyWorker;
    public bool UpgradeMenuOpen { get; private set; }

    public void StartWork(BuyUpgradeController upgradeController, AudioController audioController)
    {
        UpgradeMenuOpen = false;
        menuBg.SetActive(false);
        this.upgradeController = upgradeController;
        this.audioController = audioController;
    }
    private void OnMouseDown()
    {
        audioController.PlayOpenPanel();
        if (UpgradeMenuOpen)
        {
            UpgradeMenuOpen = false;
            menuBg.SetActive(false);
            upgradeController.CloseAllPanels();
            if (curBuyWorker != null)
            {
                curBuyWorker.gameObject.SetActive(false);
            }
        }
        else
        {
            UpgradeMenuOpen = true;
            menuBg.SetActive(true);
            if (curBuyWorker != null)
            {
                curBuyWorker.gameObject.SetActive(true);
            }
        }
    }
    public void GetBuyWorker(BuyWorker buyWorker)
    {
        curBuyWorker = buyWorker;
        curBuyWorker.gameObject.SetActive(UpgradeMenuOpen);
    }
}
