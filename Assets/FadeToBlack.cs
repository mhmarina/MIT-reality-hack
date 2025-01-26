using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] Image screen;

    private void Update()
    {
        Color color = screen.color;
        color.a = color.a + 0.1f * Time.deltaTime;
        screen.color = color;
    }
}
