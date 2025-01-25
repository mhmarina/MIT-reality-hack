using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float maxTime = 30f;
    public float timeRemaining;
    [HideInInspector] bool isStopped = false;

    void Start()
    {
        timeRemaining = maxTime;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && !isStopped)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
        }
        else if (!isStopped)
        {
            isStopped = true;
            onTimeStop();
        }
    }

    void onTimeStop()
    {
        //do something
        this.gameObject.SetActive(false);
    }
}
