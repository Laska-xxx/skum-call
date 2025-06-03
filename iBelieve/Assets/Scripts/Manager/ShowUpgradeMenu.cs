using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBg;
    private BuyUpgradeController upgradeController;
    public bool UpgradeMenuOpen { get; private set; }
    private AudioController audioController;
    private BuyWorker curBuyWorker;
    void Start()
    {
        UpgradeMenuOpen = false;
        menuBg.SetActive(false);
        upgradeController = FindObjectOfType<BuyUpgradeController>();
        audioController = FindObjectOfType<AudioController>();
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
    }
}
