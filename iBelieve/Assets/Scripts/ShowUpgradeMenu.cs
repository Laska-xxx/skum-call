using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBg;
    private BuyUpgradeWorker[] buyUpgradeWorkers;
    private BuyWorker[] buyeWorkers;
    public bool UpgradeMenuOpen { get; private set; }
    void Start()
    {
        UpgradeMenuOpen = false;
        menuBg.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (UpgradeMenuOpen)
        {
            UpgradeMenuOpen = false;
            menuBg.SetActive(false);
            buyUpgradeWorkers = FindObjectsOfType<BuyUpgradeWorker>();
            buyeWorkers = FindObjectsOfType<BuyWorker>();
            foreach (var worker in buyUpgradeWorkers)
            {
                worker.Close();
            }
            foreach (var worker in buyeWorkers)
            {
                worker.Close();
            }
        }
        else
        {
            UpgradeMenuOpen = true;
            menuBg.SetActive(true);
        }
    }
}
