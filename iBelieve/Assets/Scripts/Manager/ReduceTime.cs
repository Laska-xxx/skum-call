using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    public Worker[] workers;
    private ShowUpgradeMenu menu;
    void Start()
    {
        workers = FindObjectsOfType<Worker>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !menu.UpgradeMenuOpen)
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
