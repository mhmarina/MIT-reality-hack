using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] Image screen;
    bool isFading = false;

    private void Update()
    {
        if(isFading && screen.color.a < 1)
        {
            Color color = screen.color;
            color.a = color.a + 0.1f * Time.deltaTime;
            screen.color = color;
        }
    }

    public void startFading()
    {
        isFading = true;
    }
}
