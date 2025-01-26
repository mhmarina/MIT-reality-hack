using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // rotating axis (y-axis)
    public float speed = 10f; // rotation speed (dps)

    void Update()
    {
        transform.Rotate(rotationAxis * speed * Time.deltaTime); // rotates object
    }
}
