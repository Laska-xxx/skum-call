using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoughtWorkers : MonoBehaviour 
{
    public List<GameObject> workers;
    public void AddWorker(GameObject worker)
    {
        workers.Add(worker);
    }
}
