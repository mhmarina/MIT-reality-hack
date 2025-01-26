using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class IntroSceneSpawner : MonoBehaviour
{
    public GameObject prefabB; // Prefab B (generated objects)
    public int spawnCount = 5; // Number of objects to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Spawn area size
    public Transform objectA; // Reference to Object A (clickable object)
    public Vector3 offset = Vector3.zero; // Offset for spawn position adjustment

    public float floatRange = 1f; // Floating range
    public float floatSpeed = 2f; // Floating speed

    private void Start()
    {
        // Ensure objectA has XRBaseInteractable for interaction
        XRBaseInteractable interactable = objectA.GetComponent<XRBaseInteractable>();
        if (interactable == null)
        {
            interactable = objectA.gameObject.AddComponent<XRBaseInteractable>();
        }

        // Bind the OnSelectEntered event to handle the click
        interactable.selectEntered.AddListener(OnObjectAClicked);
    }

    private void OnObjectAClicked(SelectEnterEventArgs args)
    {
        // Generate objectB
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnObjectB();
        }

        // Remove or disable objectA
        if (objectA != null)
        {
            Destroy(objectA.gameObject);
        }
    }

    private void SpawnObjectB()
    {
        // Calculate the base position using objectA's position and the offset
        Vector3 basePosition = objectA.position + offset;

        // Randomize position within the spawn area
        Vector3 randomPosition = basePosition + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Generate a random rotation
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f)
        );

        // Instantiate prefabB at the calculated position and rotation
        GameObject instance = Instantiate(prefabB, randomPosition, randomRotation);

        // Add floating and other custom logic to the instance
        AddFloatingEffect(instance);
        AddCustomLogic(instance);
    }

    private void AddFloatingEffect(GameObject instance)
    {
        FloatingObject floating = instance.AddComponent<FloatingObject>();
        floating.floatRange = floatRange;
        floating.floatSpeed = floatSpeed;
    }

    private void AddCustomLogic(GameObject instance)
    {
        // Add other behaviors or logic specific to objectB
        instance.AddComponent<ObjectInteraction>();
    }

    // Nested FloatingObject class for floating behavior
    private class FloatingObject : MonoBehaviour
    {
        public float floatRange = 1f;
        public float floatSpeed = 2f;

        private Vector3 startPosition;
        private float randomOffset;
        private Rigidbody rb;

        void Start()
        {
            startPosition = transform.position;
            randomOffset = Random.Range(0f, 2f * Mathf.PI);

            // Add or get Rigidbody component
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
            rb.isKinematic = true; // Set as kinematic to prevent physical forces
        }

        void FixedUpdate()
        {
            // Calculate floating offset
            float offsetY = Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatRange;

            // Calculate target position
            Vector3 targetPosition = startPosition + new Vector3(0, offsetY, 0);

            // Move the object using Rigidbody.MovePosition
            rb.MovePosition(targetPosition);
        }
    }
}
