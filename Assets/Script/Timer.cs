using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] public float maxTime = 30f; // Total time in seconds
    public float timeRemaining; // Remaining time
    [HideInInspector] bool isStopped = false; // Flag to indicate if the timer is stopped

    public ObjectInteraction objectInteraction; // Reference to the score logic script
    public GameObject objectA; // Object to display if the score is greater than 10
    public GameObject objectB; // Object to display if the score is 10 or less

    void Start()
    {
        timeRemaining = maxTime; // Initialize the timer with the maximum time
    }

    void Update()
    {
        if (timeRemaining > 0 && !isStopped)
        {
            timeRemaining -= Time.deltaTime; // Decrease remaining time by delta time
        }
        else if (!isStopped)
        {
            isStopped = true; // Stop the timer
            onTimeStop(); // Handle actions when time stops
        }
    }

    void onTimeStop()
    {
        this.gameObject.SetActive(false); // Deactivate the timer object

        // Get the final score from ObjectInteraction
        int finalScore = objectInteraction.score;
        Debug.Log($"Final Score: {finalScore}"); // Log the final score

        // Display Object A or Object B based on the score
        if (finalScore > 10)
        {
            objectA.SetActive(true); // Activate Object A
            Debug.Log("Score is greater than 10, displaying Object A.");
        }
        else
        {
            objectB.SetActive(true); // Activate Object B
            Debug.Log("Score is 10 or less, displaying Object B.");
        }
    }
}
