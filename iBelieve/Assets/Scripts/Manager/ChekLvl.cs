using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChekLvl : MonoBehaviour
{
    private List <Worker> workers = new List<Worker>();
    private List <Desk> desks = new List<Desk>();
    private EndController endController;
    private AchivController achivController;
    private int generalWorkerLevel;
    private int needGeneralWorkerLevel;

    public void StartWork(EndController end, AchivController achiv)
    {
        endController = end;
        achivController = achiv;
        
    }
    public void ChekWorkerLvl(Worker newWorker)
    {
        workers.Add(newWorker);
    
        generalWorkerLevel = 0;
        int cur = 0;
        foreach (Worker worker in workers)
        {
            
            generalWorkerLevel += worker.Level;
            if (worker.Level >= 20)
            {
                cur++;
            }
        }
        if (cur == 5)
        {
            achivController.GetWorkerLvlAchiv(100);
            StartCoroutine(ChekGeneralWorkerLevel());
        }
    }
    public void ChekDeskLvl(Desk newDesk)
    {
        desks.Add(newDesk);
        generalWorkerLevel = 0;
        foreach (Desk desk in desks)
        {
            generalWorkerLevel += desk.Level;
        }
        if (generalWorkerLevel == 100)
        {
            achivController.GetDeskLvlAchiv(generalWorkerLevel);
        }
    }
    public IEnumerator ChekGeneralWorkerLevel()
    {
        if (workers.Count == 0)
        {
            Worker[] curWorkers = FindObjectsOfType<Worker>();
            workers.AddRange(curWorkers);
        }
        needGeneralWorkerLevel = Random.Range((workers[0].MaxLevel-5) * 5, (workers[0].MaxLevel) * 5);
        while (generalWorkerLevel < needGeneralWorkerLevel)
        {
            generalWorkerLevel = 0;
            foreach (Worker worker in workers)
            {
                generalWorkerLevel += worker.Level;
            }
            yield return new WaitForSeconds(1);
        }
        endController.StartEnd();
    }
}
