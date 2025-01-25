using UnityEngine;

public class Swim : MonoBehaviour
{
    public float frequency = 1.0f; // Speed of the sine wave
    public float amplitude = 1.0f; // Height of the sine wave
    public float orbitSpeed = 0.5f;  // Speed of the circular movement
    public float radius = 10f;  // Radius of the circular path

    private Vector3 centerPoint;
    private Vector3 lastPosition;
    private Vector3 newPosition;
    private float angle;

    void Start()
    {
        frequency = Random.Range(0.5f, 1.5f); // Random frequency range for some variation
        centerPoint = transform.position; // Set the center point
        angle = 0; // Initialize angle
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the vertical position using a sine wave
        float y = Mathf.Sin(Time.time * frequency) * amplitude;

        // Calculate the circular position
        angle += orbitSpeed * Time.deltaTime;
        float x = centerPoint.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.z + Mathf.Sin(angle) * radius;

        // Set the new position
        transform.position = new Vector3(x, centerPoint.y + y, z);
        newPosition = transform.position;
        Vector3 direction = newPosition - lastPosition;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        lastPosition = newPosition; 
    }
}
