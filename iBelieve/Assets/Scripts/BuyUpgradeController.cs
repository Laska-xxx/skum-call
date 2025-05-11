using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeController : MonoBehaviour
{
    private BuyUpgradeWorker[] buyUpgradeWorkers;
    private BuyWorker[] buyeWorkers;
    private BuyUpgradeDesk[] buyUpgradeDesks;
    
    public void CloseAllPanels()
    {
        buyUpgradeWorkers = FindObjectsOfType<BuyUpgradeWorker>();
        buyeWorkers = FindObjectsOfType<BuyWorker>();
        buyUpgradeDesks = FindObjectsOfType<BuyUpgradeDesk>();
        foreach (var buyWorker in buyUpgradeWorkers)
        {
            buyWorker.Close();
        }
        foreach (var worker in buyeWorkers)
        {
            worker.Close();
        }
        foreach (var desk in buyUpgradeDesks)
        {
            desk.Close();
        }
    }
}
