using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    // Prefab that can be set through the Inspector
    public GameObject prefab;

    // External variable to control the number of spawned prefabs
    public int spawnCount = 5;

    // Defines the range of positions for spawning
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);

    // Starting position (external variable)
    public Vector3 startPosition = Vector3.zero;

    // Floating range and speed (configurable through Inspector)
    public float floatRange = 1f; // Range of floating
    public float floatSpeed = 2f; // Speed of floating

    void Start()
    {
        // Check if the Prefab has been assigned
        if (prefab == null)
        {
            Debug.LogError("Prefab is not set!");
            return;
        }

        // Instantiate the specified number of prefabs
        for (int i = 0; i < spawnCount; i++)
        {
            // Randomly generate positions based on the starting position and range
            Vector3 randomPosition = startPosition + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            // Instantiate the prefab
            GameObject instance = Instantiate(prefab, randomPosition, Quaternion.identity);

            // Add a floating script to each instance
            FloatingObject floating = instance.AddComponent<FloatingObject>();
            floating.floatRange = floatRange;
            floating.floatSpeed = floatSpeed;
        }
    }
}
