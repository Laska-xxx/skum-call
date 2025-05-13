using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject busterImage;
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
        if (IsDobleSallary)
        {
            foreach (Worker worker in workers)
            {
                desk = worker.gameObject.GetComponent<Desk>();
                coins.AddCoins(worker.Sallary * 2 * (time / desk.Cooldown));
            }
        }
        else
        {
            foreach (Worker worker in workers)
            {
                desk = worker.gameObject.GetComponent<Desk>();
                coins.AddCoins(worker.Sallary * (time / desk.Cooldown));
            }
        }

    }

    public void DobleSellary(int time)
    {
        if (IsDobleSallary)
        {
            busterImage.GetComponent<BusterTimer>().Timer += time;
        }
        else
        {
            IsDobleSallary = true;
            busterImage.SetActive(true);
            busterImage.GetComponent<BusterTimer>().Timer += time;
        }
    }

    public void StopDobleSallary()
    {
        Debug.Log("stopDobleSallary");
        IsDobleSallary = false;
        busterImage.SetActive(false);
    }
}
