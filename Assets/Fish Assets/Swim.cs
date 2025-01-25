using UnityEngine;

public class Swim : MonoBehaviour
{
    public float frequency; // Speed of the sine wave
    public float amplitude = 1.0f; // Height of the sine wave
    public float forwardSpeed = 5.0f; // Speed of the forward movement

    private Vector3 startPosition;

    void Start()
    {
        frequency = Random.Range(-1.0f, 1.0f);
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(0, newY, 0);
    }
}

