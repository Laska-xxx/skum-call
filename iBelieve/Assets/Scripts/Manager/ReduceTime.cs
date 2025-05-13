using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    public Worker[] workers;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private AudioController audioController;

    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        audioController = FindObjectOfType<AudioController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen)
        {
            audioController.PlayClick();
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
