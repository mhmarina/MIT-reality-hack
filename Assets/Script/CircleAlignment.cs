using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAlignment : MonoBehaviour
{

    public GameObject[] objects; // objects in circle
    public float radius = 5f; // radius of circle

    void Start()
    {
        int objectCount = objects.Length;

        for (int i = 0; i < objectCount; i++) {
            float angle = i * Mathf.PI * 2 / objectCount; // calculates angle of each object
            Vector3 position = transform.position + new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius); // calculates position in circle
            objects[i].transform.position = position; // set objects to respective positions
            objects[i].transform.LookAt(transform.position); // set objects to face the center
        }
    }
}