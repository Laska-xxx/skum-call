using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWorker : MonoBehaviour
{
    [SerializeField] private Workers workerData;
    [SerializeField] private Button button;
    private GameObject iconImage;
    private GameObject levelText;
    private BuyWorker ded;
    void Start()
    {
        ded = gameObject.GetComponentInParent<BuyWorker>();
        iconImage = gameObject.transform.Find("IconImage").gameObject;
        iconImage.GetComponent<Image>().sprite = workerData.Icon;
        levelText = gameObject.transform.Find("LevelText").gameObject;
        levelText.GetComponent<TextMeshProUGUI>().text = $"Level: {workerData.Level}";
        button.onClick.AddListener(StartBuy);
    }

    private void StartBuy()
    {
        ded.Buy(workerData);
    }
}
