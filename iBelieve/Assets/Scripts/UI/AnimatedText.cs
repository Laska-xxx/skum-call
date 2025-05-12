using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] private float speedText = 0.06f;
    [SerializeField] private TextMeshProUGUI text;
    private string story;

    void Start()
    {
        story = text.text;
        text.text = "";
        StartCoroutine("PlayText"); ;
    }
    
    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            text.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

}
