using UnityEngine;

public class PSpawner : MonoBehaviour
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

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(
                Random.Range(0f, 360f), // Random X rotation
                Random.Range(0f, 360f), // Random Y rotation
                Random.Range(0f, 360f)  // Random Z rotation
            );

            // Instantiate the prefab with random position and rotation
            GameObject instance = Instantiate(prefab, randomPosition, randomRotation);

            // Add floating behavior directly in this script
            FloatingObject floating = instance.AddComponent<FloatingObject>();
            floating.floatRange = floatRange;
            floating.floatSpeed = floatSpeed;
        }
    }

    // Nested FloatingObject class
    private class FloatingObject : MonoBehaviour
    {
        public float floatRange = 1f; // Range of floating
        public float floatSpeed = 2f; // Speed of floating

        private Vector3 startPosition;
        private float randomOffset;

        void Start()
        {
            // Record the initial position and set a random phase offset
            startPosition = transform.position;
            randomOffset = Random.Range(0f, 2f * Mathf.PI);
        }

        void Update()
        {
            // Calculate floating offset using sine wave
            float offsetY = Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatRange;
            transform.position = startPosition + new Vector3(0, offsetY, 0);
        }
    }
}