using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    public Worker[] workers;
    private BossAnim bossAnim;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private AudioController audioController;

    void Start()
    {
        menu = FindObjectOfType<ShowUpgradeMenu>();
        bossAnim = FindObjectOfType<BossAnim>();
        gameUIController = FindObjectOfType<GameUIController>();
        audioController = FindObjectOfType<AudioController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.AchievementOpen && !gameUIController.SettingsOpen)
        {
            audioController.PlayClick();
            foreach (Worker worker in workers)
            {
                worker.ReduceTimer();
                worker.GetComponentInChildren<AnimController>().ClickAnim();
                bossAnim.ClickAnim();
            }
        }
    }

    public void FindWorkers()
    {
        workers = FindObjectsOfType<Worker>();
    }
}
