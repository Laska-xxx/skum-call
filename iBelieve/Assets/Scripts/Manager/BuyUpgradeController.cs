using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeController : MonoBehaviour
{
    private BuyUpgradeWorker[] buyUpgradeWorkers;
    private BuyWorker[] buyWorkers;
    private BuyUpgradeDesk[] buyUpgradeDesks;
    
    public void CloseAllPanels()
    {
        buyUpgradeWorkers = FindObjectsOfType<BuyUpgradeWorker>();
        buyWorkers = FindObjectsOfType<BuyWorker>();
        buyUpgradeDesks = FindObjectsOfType<BuyUpgradeDesk>();
        foreach (var buyWorker in buyUpgradeWorkers)
        {
            buyWorker.Close();
        }
        foreach (var worker in buyWorkers)
        {
            worker.CloseChouseWorker();
        }
        foreach (var desk in buyUpgradeDesks)
        {
            desk.Close();
        }
    }
}
