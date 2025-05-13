using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BusterTimer : MonoBehaviour
{
    private TextMeshProUGUI busterTimerText;
    private Shop shop;
    public float Timer = 0;
    void Start()
    {
        busterTimerText = GetComponentInChildren<TextMeshProUGUI>();
        shop = FindObjectOfType<Shop>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60f);
        int seconds = Mathf.FloorToInt(Timer % 60f);
        busterTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (Timer <= 0)
        {
            shop.StopDobleSallary();
        }
    }
    private void OnDisable()
    {
        Timer = 0;
    }

    

}
