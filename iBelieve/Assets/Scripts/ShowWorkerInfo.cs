using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWorkerInfo : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] private TextMeshProUGUI infoText;
    private Worker worker;
    void Start()
    {
        worker = gameObject.GetComponentInParent<Worker>();
        infoPanel.SetActive(false);
        labelText.GetComponent<TextMeshProUGUI>().text = $"{worker.persName}";
    }

    private void OnMouseOver()
    {
        infoText.GetComponent<TextMeshProUGUI>().text = $"Level: {worker.level}\r\nSelary: 5 coins\r\nCooldown: 15 sec";
        infoPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
