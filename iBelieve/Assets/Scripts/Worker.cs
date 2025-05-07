using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Workers workerData;
    private GameObject sprite;
    public string persName {  get; private set; }
    public int level { get; private set; }
    private int tilent;
    private GameObject buyWorker;
    void Start()
    {
        Debug.Log($"3{workerData}");
        sprite = gameObject.transform.Find("Pers").gameObject;
        sprite.GetComponent<SpriteRenderer>().sprite = workerData.Sprite;
        persName = workerData.PersName;
        level = workerData.Level;
        tilent = workerData.Tilent;
    }


    void Update()
    {
        
    }
}
