using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxTime = 30f;
    [HideInInspector] float timeRemaining;
    [HideInInspector] bool isStopped = false;

    void Start()
    {
        timeRemaining = maxTime;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            isStopped = false;
            timeRemaining -= Time.deltaTime;
        }
        else { isStopped = true; }
    }
}
