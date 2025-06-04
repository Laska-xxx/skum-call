using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    [SerializeField] private GameObject cheatsPanel;
    [SerializeField] private GameObject field;
    [SerializeField] private Button useButton;
    [SerializeField] private Button closeButton;
    private float curValue;
    private Coins coins;
    /*void Start()
    {
        coins = FindObjectOfType<Coins>();
        cheatsPanel.SetActive(false);
        useButton.onClick.AddListener(UseCheats);
        closeButton.onClick.AddListener(() => cheatsPanel.SetActive(false));
    }*/
    public void StartWork(Coins coins)
    {
        this.coins = coins;
        cheatsPanel.SetActive(false);
        useButton.onClick.AddListener(UseCheats);
        closeButton.onClick.AddListener(() => cheatsPanel.SetActive(false));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) & !cheatsPanel.activeInHierarchy)
        {
            cheatsPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            cheatsPanel.SetActive(false);
        }
    }

    private void UseCheats()
    {
        if (float.TryParse(field.GetComponent<TMP_InputField>().text, out curValue))
        {
            curValue = float.Parse(field.GetComponent<TMP_InputField>().text);
            coins.AddCoins(curValue);
            field.GetComponent<TMP_InputField>().text = "";
            cheatsPanel.SetActive(false);
        }
    }
}
