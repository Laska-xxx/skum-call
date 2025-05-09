using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject[] upgrads;
    [SerializeField] private int startCooldown = 25;
     public int Cooldown { get; private set; }
    [SerializeField] private int cost = 15;
    public float UpgradeCost { get; private set; }
    public int Level { get; private set; } = 1;
    private Worker worker;
    
    
    void Start()
    {
        worker = gameObject.GetComponentInParent<Worker>();
        Cooldown = startCooldown;
        UpgradeCost = cost;
    }

    
    public void LevelUp()
    {
        Level++;
        Cooldown =FutureCooldown(Level);
        UpgradeCost = Mathf.Round(cost * (Mathf.Pow(1.45f, Level)));
        if (Level % 5 == 0 && Level <= 20)
        {
            foreach (GameObject obj in gameObject.GetComponentsInChildren<GameObject>())
            {
                Destroy(obj);
            }
            /*Instantiate(upgrads[lvl/5], gameObject.transform);*/
        }
    }
    public int FutureCooldown(int lvl)
    {
        return startCooldown - lvl;
    }
}
