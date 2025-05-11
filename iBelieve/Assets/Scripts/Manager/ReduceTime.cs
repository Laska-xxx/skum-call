using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    public Worker[] workers;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen)
        {
            foreach (Worker worker in workers)
            {
                worker.ReduceTimer();
                worker.GetComponentInChildren<AnimController>().ClickAnim();
            }
        }
    }

    public void FindWorkers()
    {
        workers = FindObjectsOfType<Worker>();
    }
}
