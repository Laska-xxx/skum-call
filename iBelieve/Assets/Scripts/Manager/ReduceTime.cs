using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    public Worker[] workers;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;

    private AudioSource clickAudio;
    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();

        clickAudio = GameObject.Find("ClickSource").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen)
        {
            clickAudio.Play();
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
