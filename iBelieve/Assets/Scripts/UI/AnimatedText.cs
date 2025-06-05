using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] private float speedText = 0.05f;
    private TextMeshProUGUI text;
    private string story;

    private void OnEnable()
    {
        speedText = 0.05f;
        text = GetComponent<TextMeshProUGUI>();
        story = text.text;
        text.text = "";
        StartCoroutine("PlayText"); ;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            StopCoroutine("PlayText");
            text.text = story;
        }
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
