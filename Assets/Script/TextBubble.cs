using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bubble;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] string text = "";

    public void spawnBubble()
    {
        if(bubble != null)
        {
            bubble.SetActive(true);
        }
        if(textMeshPro != null)
        {
            textMeshPro.text = text;   
        }
    }
}
