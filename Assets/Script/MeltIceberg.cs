using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltIceberg : MonoBehaviour
{
    public Timer timer;
    public float maxTime;
    [HideInInspector] Vector3 initialSize;
    public Vector3 finalSize = new Vector3(0.1f, 0.1f, 0.1f); // size of iceberg when timer ends

    void Start()
    {
        initialSize = transform.localScale; // stores iceberg's original scale
        Debug.Log(initialSize);

        if (timer != null) {
            maxTime = timer.maxTime;
        }
        else {
            Debug.LogError("Cannot reference timer script");
        }
    }

    void Update()
    {
        if (timer != null) {
            float t = timer.timeRemaining / maxTime; // calculates interpolation factor based on timer
            transform.localScale = initialSize * t; // gradually shrinks the iceberg
            
            // stops shrinking iceberg when the timer passes the max time
            if (timer.timeRemaining <= 0) {
                transform.localScale = finalSize;
            }
        }
    }
}
