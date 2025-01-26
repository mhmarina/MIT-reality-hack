using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Bubbles foams; // Reference to Foams, used for spawning objects

    private int spawnIndex = 0; // Current spawn index (1-2-3 loop)
    public int score = 0; // Public score variable to track points

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggered object has the tag "Recyclable"
        if (other.CompareTag("Recyclable"))
        {
            spawnIndex = (spawnIndex + 1) % 3; // Loop the spawn index (0-1-2-0)
            foams.SpawnObject(spawnIndex); // Call the spawn method from Foams
            Destroy(other.gameObject); // Destroy the object placed in the trash

            score++; // Increment the score by 1
            Debug.Log($"Spawned Object Index: {spawnIndex + 1}, Score: {score}"); // Log current spawn index and score
        }
    }
}
