using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Desk desk;
    private Worker[] workers;
    private Coins coins;
    public bool IsDobleSallary { get; private set; } = false;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
    }

    public void SkipTime(int time)
    {
        workers = FindObjectsOfType<Worker>();
        foreach (Worker worker in workers)
        {
            desk = worker.gameObject.GetComponent<Desk>();
            coins.AddCoins(worker.Sallary * (time / desk.Cooldown));
        }

    }

    public void DobleSellary(int time)
    {
        IsDobleSallary = true;
        Invoke("StopDobleSallary", time);
    }

    private void StopDobleSallary()
    {
        IsDobleSallary = false;
    }
}
