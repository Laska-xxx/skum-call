using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    [SerializeField] private GameObject clickParticlObj;
    public List <Worker> workers {  get; private set; } = new List <Worker>();
    private BossController bossAnim;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private AudioController audioController;

    public void StartWork(ShowUpgradeMenu showUpgradeMenu, GameUIController gameUIController, AudioController audioController)
    {
        menu = showUpgradeMenu;
        bossAnim = FindObjectOfType<BossController>();
        this.gameUIController = gameUIController;
        this.audioController = audioController;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.AchievementOpen && !gameUIController.SettingsOpen)
        {
            audioController.PlayClick();
            ClickEffect(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            foreach (Worker worker in workers)
            {
                worker.ReduceTimer();
                worker.GetComponentInChildren<AnimController>().ClickAnim();
            }
            bossAnim.ClickAnim();
        }
    }
    public void GetWorker(Worker curWorker)
    {
        workers.Add(curWorker);
    }
    private void ClickEffect(Vector2 position)
    {
        clickParticlObj.transform.position = position;
        clickParticlObj.GetComponent<ParticleSystem>().Play();
    }
}
